using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField] BattleUIManager uiManager;
    [SerializeField] EncounterSO placeholderEncounter;
    public PlayerMovement player;
    public Battle currentBattle;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartBattle(placeholderEncounter);
        }
        if (Input.GetKeyDown(KeyCode.G) && currentBattle != null)
        {
            EndBattle();
        }
    }

    public void StartBattle(EncounterSO encounter)
    {
        if (currentBattle != null) return;
        player.canMove = false;
        currentBattle = new Battle(encounter);
        uiManager.SetupBattle(encounter);
        currentAbilityUsage = new AbilityUsage();
        currentAbilityUsage.battle = currentBattle;
        uiManager.DisableActionButtons();
        uiManager.HideArrow();
        UpdateAllUI();
        StartCoroutine("FirstTurn");
    }

    IEnumerator FirstTurn()
    {
        yield return new WaitForSeconds(1f);
        CheckForGlobalTurnStart();
        if (!currentBattle.GetCurrentActingUnit().isEnemy)
        {
            uiManager.EnableActionButtons();
        }
        uiManager.ShowArrow();
        uiManager.MoveArrowToUnit(currentBattle.GetCurrentActingUnitIndex());
        foreach (int passiveID in currentBattle.GetCurrentActingUnit().GetBaseCharacter().passiveAbilityIDs)
        {
            foreach (int effectID in Helper.GetPassiveAbility(passiveID).effectIDs)
            {
                Helper.GetEffect(effectID).UserTurnStarts(currentBattle.GetCurrentActingUnit(), currentBattle);
            }
        }
        UpdateAllUI();
    }

    bool CheckForBattleEnd()
    {
        if (currentBattle.AliveEnemyCount() == 0)
        {
            EndBattle();
            return true;
        }
        return false;
    }

    IEnumerator NextTurn()
    {
        if (CheckForBattleEnd()) yield return 0;
        Debug.Log("Current " + currentBattle.GetCurrentActingUnit().GetBaseCharacter().unitName);
        currentBattle.GetCurrentActingUnit().CountdownStatuses();
        currentBattle.EndTurn();
        Debug.Log("Switched to " + currentBattle.GetCurrentActingUnit().GetBaseCharacter().unitName);

        CheckForGlobalTurnStart();

        if (currentBattle.GetCurrentActingUnit().isDead)
        {
            Debug.Log("Dead, so we switch to " + currentBattle.GetCurrentActingUnit().GetBaseCharacter().unitName);
            StartCoroutine(NextTurn());
            yield return 0;
        }

        Helper.ActivateTurnStartPassiveEffects();

        yield return StartCoroutine(HandleFuas());

        if (currentBattle.GetCurrentActingUnit().isEnemy)
        {
            uiManager.DisableActionButtons();
            StartCoroutine(HandleEnemyAction());
        } 
        else
        {
            //uiManager.MoveSpriteForward(currentBattle.GetCurrentActingUnitIndex(), 1);
            uiManager.EnableActionButtons();
        }
        uiManager.MoveArrowToUnit(currentBattle.GetCurrentActingUnitIndex());
        UpdateAllUI();
        currentAbilityUsage = new AbilityUsage();
        currentAbilityUsage.battle = currentBattle;
    }

    Ability currentAbility;
    AbilityUsage currentAbilityUsage;

    IEnumerator HandleEnemyAction()
    {
        yield return new WaitForSeconds(0.5f);
        EnemyUnit currentActingEnemy = (EnemyUnit)currentBattle.GetCurrentActingUnit();
        currentAbilityUsage.user = currentActingEnemy;
        int randomAbilityID = currentActingEnemy.baseCharacter.activeAbilityIDs[Random.Range(0, currentActingEnemy.baseCharacter.activeAbilityIDs.Length)];
        currentAbility = GameManager.instance.idManager.abilities[randomAbilityID];
        int teamSize = GameManager.instance.teamManager.teamUnits.Length;
        if (!currentAbility.abilityTargetsAlly)
        {
            int selectedUnit = Random.Range(0, teamSize);
            while (currentBattle.GetUnitAt(selectedUnit).isDead)
            {
                selectedUnit = Random.Range(0, teamSize);
            }
            currentAbilityUsage.selectedUnit = selectedUnit;
        } 
        else
        {
            currentAbilityUsage.selectedUnit = Random.Range(teamSize, currentBattle.EnemyCount() + teamSize);
        }
        currentAbility.UseAbility(currentAbilityUsage);
        UpdateAllUI();
        yield return new WaitForSeconds(1f);
        yield return StartCoroutine(HandleFuas());
        if (currentAbility.dontEndTurn)
        {
            if (!CheckForBattleEnd())
                StartCoroutine(HandleEnemyAction());
        }
        else
        {
            StartCoroutine(NextTurn());
        }
    }

    public void SelectAction(int action)
    {
        if (currentBattle.GetCurrentActingUnit().isEnemy) return;

        switch (action)
        {
            case 1:
                CharacterUnit currentActingCharacter = (CharacterUnit)currentBattle.GetCurrentActingUnit();
                ChoosePlayerAbility(Helper.GetAbility(currentActingCharacter.baseCharacter.attackAbilityID));
                uiManager.DisableActionButtons();
                break;
            case 2:
                uiManager.OpenAbilitySelectionMenu();
                uiManager.DisableActionButtons();
                break;
        }
    }

    public void ChoosePlayerAbility(Ability ability)
    {
        if (currentBattle.GetCurrentActingUnit().isEnemy) return;

        currentAbilityUsage.user = currentBattle.GetCurrentActingUnit();
        currentAbility = ability;

        uiManager.CloseAbilitySelectionMenu();

        if (currentAbility.noTarget)
        {
            currentAbilityUsage.selectedUnit = -1;
            StartCoroutine(HandlePlayerAction());
        }
        else
        {
            uiManager.StartTargetSelection(currentAbility.abilityTargetsAlly);
        }
    }

    public void SelectTarget(int unit)
    {
        currentAbilityUsage.selectedUnit = unit;
        uiManager.StopTargetSelection();

        StartCoroutine(HandlePlayerAction());
    }

    IEnumerator HandlePlayerAction()
    {
        yield return new WaitForSeconds(0.5f);
        currentAbility.UseAbility(currentAbilityUsage);
        currentAbilityUsage.user.ConsumeMP(currentAbility.MPcost);
        currentAbilityUsage.user.ConsumeTP(currentAbility.TPcost);
        currentAbilityUsage.user.RegenerateTP(currentAbility.TPgain);
        UpdateAllUI();
        yield return new WaitForSeconds(1f);
        yield return StartCoroutine(HandleFuas());
        if (currentAbility.dontEndTurn)
        {
            if (!CheckForBattleEnd())
                uiManager.EnableActionButtons();
        } 
        else
        {
            Debug.Log("Going to next turn");
            StartCoroutine(NextTurn());
        }
    }

    public void AddFuaToQueue(FUAUsage fua, bool addFirst = false)
    {
        if (currentBattle != null)
        {
            currentBattle.AddFuaToQueue(fua, addFirst);
        }
    }

    IEnumerator HandleFuas()
    {
        foreach (FUAUsage fua in currentBattle.fuaQueue.ToArray())
        {
            FollowUpAttack usedFua = Helper.GetFUA(fua.fuaID);
            usedFua.UnleashFUA(fua);
            currentBattle.fuaQueue.Remove(fua);
            yield return new WaitForSeconds(usedFua.duration);
        }
    }

    public void EndBattle()
    {
        if (currentBattle == null) return;
        uiManager.StopBattle();
        currentBattle = null;
        player.canMove = true;
    }

    public void SpawnFloatingTextOnUnit(BattleUnit unit, string text, Color color)
    {
        if (currentBattle == null) return;

        for (int i = 0; i < currentBattle.GetAllUnits().Count; i++)
        {
            if (currentBattle.GetUnitAt(i) == unit)
            {
                uiManager.SpawnFloatingTextOnUnit(i, text, color);
            }
        }
    }

    public void UpdateSpriteDeathState(BattleUnit unit)
    {
        if (currentBattle == null) return;

        for (int i = 0; i < currentBattle.GetAllUnits().Count; i++)
        {
            if (currentBattle.GetUnitAt(i) == unit)
            {
                uiManager.UpdateBattleSpriteDeathState(i, unit.isDead);
            }
        }
    }

    public void UpdateAllSpritesDeathState()
    {
        if (currentBattle == null) return;

        for (int i = 0; i < currentBattle.GetAllUnits().Count; i++)
        {
            uiManager.UpdateBattleSpriteDeathState(i, currentBattle.GetUnitAt(i).isDead);
        }
    }

    public void FlashBattleSprite(BattleUnit unit, Color color, float startupTime, float duration, float endTime)
    {
        for (int i = 0; i < currentBattle.GetAllUnits().Count; i++)
        {
            if (currentBattle.GetUnitAt(i) == unit)
            {
                uiManager.FlashBattleSprite(i, color, startupTime, duration, endTime);
            }
        }
    }

    public void UnitTakesDamage(BattleUnit unit, Damage damage)
    {
        if (currentBattle == null) return;

        foreach (BattleUnit _unit in currentBattle.GetAllUnits())
        {
            foreach (int passiveID in _unit.GetBaseCharacter().passiveAbilityIDs)
            {
                foreach (int effectID in Helper.GetPassiveAbility(passiveID).effectIDs)
                {
                    Helper.GetEffect(effectID).UnitTakesDamage(_unit, unit, currentBattle, damage);
                }
            }
        }
    }

    void CheckForGlobalTurnStart()
    {
        if (currentBattle.GetCurrentActingUnitIndex() == 0)
        {
            foreach (BattleUnit unit in currentBattle.GetAllUnits())
            {
                foreach (int passiveID in unit.GetBaseCharacter().passiveAbilityIDs)
                {
                    foreach (int effectID in Helper.GetPassiveAbility(passiveID).effectIDs)
                    {
                        Helper.GetEffect(effectID).GlobalTurnStarts(unit, currentBattle);
                    }
                }
            }
        }
    }

    void UpdateAllUI()
    {
        uiManager.UpdateAllAllyInfos();
        UpdateAllSpritesDeathState();
        currentBattle.RemoveAllDeadEnemies();
    }

    public void RemoveEnemyUI(int id)
    {
        uiManager.RemoveEnemyUI(id);
    }

    public void AddEnemyUI(EnemySO enemy)
    {
        uiManager.AddEnemyUIToBattle(enemy);
    }

    public void UpdateStatusEffectOverlay(AppliedStatus status, int unitIndex)
    {
        if (!uiManager.StatusEffectOverlayExists(status, unitIndex) && status.stacks > 0 && status.remainingTurnDuration != 0)
        {
            uiManager.CreateStatusEffectOverlay(status, unitIndex);
        }
        else if (status.stacks <= 0 || status.remainingTurnDuration <= 0)
        {
            uiManager.DestroyStatusEffectOverlay(status, unitIndex);
        }
    }
}
