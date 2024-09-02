using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class BattleUIManager : MonoBehaviour
{
    [SerializeField] GameObject battlescreenGameObject;
    [SerializeField] Transform allyBattleSpriteParent, enemyBattleSpriteParent;
    [SerializeField] GameObject allyBattleSpritePrefab, enemyBattleSpritePrefab;
    [SerializeField] Transform allyInfoUIParent;
    [SerializeField] GameObject allyInfoUIPrefab;
    BattleAllyUI[] allies;
    List<BattleUnitUI> enemies = new List<BattleUnitUI>();

    [SerializeField] Button[] actionButtons;
    [SerializeField] AbilitySelectionMenu abilitySelectionMenu;
    [SerializeField] TargetSelectionUI targetSelection;

    [SerializeField] GameObject floatingTextPrefab;
    [SerializeField] ArrowUI arrow;

    Dictionary<(AppliedStatus, int), GameObject> statusEffectOverlays = new Dictionary<(AppliedStatus, int), GameObject>();
    public void SetupBattle(EncounterSO encounter)
    {
        battlescreenGameObject.SetActive(true);
        for (int i = 0; i < encounter.enemies.Length; i++)
        {
            AddEnemyUIToBattle(encounter.enemies[i]);
        }

        allies = new BattleAllyUI[GameManager.instance.teamManager.teamUnits.Length];
        for (int i = 0; i < GameManager.instance.teamManager.teamUnits.Length; i++)
        {
            allies[i] = new BattleAllyUI();
            allies[i].SetupBattleSprite(allyBattleSpriteParent, GameManager.instance.teamManager.teamUnits[i].baseCharacter.unitWorldSprite, allyBattleSpritePrefab);
            allies[i].SetupAllyInfo(allyInfoUIParent, allyInfoUIPrefab, GameManager.instance.teamManager.teamUnits[i]);
        }
        MoveArrowToUnit(0);
    }

    public void StopBattle()
    {
        battlescreenGameObject.SetActive(false);
        foreach (BattleUnitUI enemy in enemies)
        {
            enemy.ResetBattleSprite();
        }
        foreach (BattleAllyUI ally in allies)
        {
            ally.ResetBattleSprite();
            ally.ResetAllyInfo();
        }
    }

    public void AddEnemyUIToBattle(EnemySO enemy)
    {
        enemies.Add(new BattleUnitUI());
        enemies[enemies.Count - 1].SetupBattleSprite(enemyBattleSpriteParent, enemy.unitWorldSprite, enemyBattleSpritePrefab);
    }

    public void UpdateAllAllyInfos()
    {
        foreach (BattleAllyUI ally in allies)
        {
            ally.UpdateAllyInfo();
        }
    }

    BattleUnitUI GetUnitUIAt(int index)
    {
        int teamSize = GameManager.instance.teamManager.teamUnits.Length;

        if (index >= teamSize)
        {
            return enemies[index - teamSize];
        }
        else
        {
            return allies[index];
        }
    }

    public void UpdateBattleSpriteDeathState(int unitIndex, bool isDead)
    {
        int teamSize = GameManager.instance.teamManager.teamUnits.Length;

        if (isDead)
        {
            GetUnitUIAt(unitIndex).DarkenBattleSprite();
        }
        else
        {
            GetUnitUIAt(unitIndex).UndarkenBattleSprite();
        }
    }

    public void FlashBattleSprite(int unitIndex, Color color, float startupTime, float duration, float endTime)
    {
        int teamSize = GameManager.instance.teamManager.teamUnits.Length;

        GetUnitUIAt(unitIndex).FlashColor(color, startupTime, duration, endTime);
    }

    public void DisableActionButtons()
    {
        foreach(Button button in actionButtons)
        {
            button.interactable = false;
        }
    }

    public void EnableActionButtons()
    {
        foreach (Button button in actionButtons)
        {
            button.interactable = true;
        }
    }

    // Ability selection menu

    public void OpenAbilitySelectionMenu()
    {
        abilitySelectionMenu.OpenSelectionMenu();
        UpdateAbilitySelectionMenu();
    }

    public void UpdateAbilitySelectionMenu()
    {
        CharacterUnit actingUnit = (CharacterUnit)GameManager.instance.battleManager.currentBattle.GetCurrentActingUnit();
        abilitySelectionMenu.UpdateSelectionMenu(actingUnit);
    }

    public void CloseAbilitySelectionMenu()
    {
        abilitySelectionMenu.CloseSelectionMenu();
    }

    // Item selection menu

    public void OpenItemSelectionMenu()
    {

    }

    public void UpdateItemSelectionMenu()
    {

    }

    public void CloseItemSelectionMenu()
    {

    }

    // Target selection

    public void StartTargetSelection(bool targetAlly = false)
    {
        targetSelection.CreateTargetSelectionButtons(targetAlly);
    }

    public void StopTargetSelection()
    {
        targetSelection.DestroyAllButtons();
    }

    // Floating text
        
    public void SpawnFloatingTextOnUnit(int unitIndex, string text, Color color)
    {
        GameObject floatingText = Instantiate(floatingTextPrefab, battlescreenGameObject.transform);
        int teamSize = GameManager.instance.teamManager.teamUnits.Length;

        floatingText.transform.position = GetUnitUIAt(unitIndex).battleImage.transform.position;

        if (floatingText.TryGetComponent<TMP_Text>(out TMP_Text tmptext))
        {
            tmptext.text = text;
            tmptext.color = color;
        }
    }

    // Animation for sprites

    /*
    public void StartAnimation(int unitIndex, Ability ability, AbilityUsage usage)
    {

    }

    IEnumerator UnitSpriteAnimation(int unitIndex, Ability ability, AbilityUsage usage)
    {
        yield return null;
    }

    public void MoveSpriteForward(int unitIndex, int direction)
    {
        StartCoroutine(MoveSpriteForwardCoroutine(unitIndex, direction));
    }

    IEnumerator MoveSpriteForwardCoroutine(int unitIndex, int direction)
    {
        int teamSize = GameManager.instance.teamManager.teamUnits.Length;
        int mirror = 1;

        if (unitIndex > teamSize)
        {
            mirror = -1;
        }

        float progress = 0;
        Vector3 originalPosition = GetUnitUIAt(unitIndex).battleImage.transform.position;
        int distance = 30;

        while (progress < 1)
        {
            GetUnitUIAt(unitIndex).battleImage.transform.position = Vector3.Lerp(originalPosition, originalPosition + Vector3.right * distance * direction * mirror, Helper.BezierBlend(progress));
            progress += Time.deltaTime * 1/0.25f;
            yield return new WaitForEndOfFrame();
        }

        GetUnitUIAt(unitIndex).battleImage.transform.position = originalPosition + Vector3.right * distance * direction * mirror;
        
        yield return null;
    }
    */

    // Arrow

    public void MoveArrowToUnit(int unitIndex)
    {
        int teamSize = GameManager.instance.teamManager.teamUnits.Length;
        arrow.MoveToUnit(GetUnitUIAt(unitIndex), unitIndex >= teamSize);
    }

    public void HideArrow()
    {
        arrow.HideArrow();
    }

    public void ShowArrow()
    {
        arrow.ShowArrow();
    }

    public void RemoveEnemyUI(int id)
    {
        enemies[id - GameManager.instance.teamManager.teamUnits.Length].ResetBattleSprite();
        enemies.RemoveAt(id - GameManager.instance.teamManager.teamUnits.Length);
    }

    public void CreateStatusEffectOverlay(AppliedStatus status, int unitIndex)
    {
        if (Helper.GetStatus(status.statusID).overlay == null) return;
        Debug.Log("spawning overlay");
        GameObject spawnedOverlay = Instantiate(Helper.GetStatus(status.statusID).overlay, GetUnitUIAt(unitIndex).battleImage.transform.position, Quaternion.identity, battlescreenGameObject.transform);
        Debug.Log("overlay = " + spawnedOverlay);
        statusEffectOverlays.Add((status, unitIndex), spawnedOverlay);
    }

    public void DestroyStatusEffectOverlay(AppliedStatus status, int unitIndex)
    {
        if (Helper.GetStatus(status.statusID).overlay == null) return;
        Destroy(statusEffectOverlays[(status, unitIndex)]);
        statusEffectOverlays.Remove((status, unitIndex));
    }

    public bool StatusEffectOverlayExists(AppliedStatus status, int unitIndex)
    {
        return statusEffectOverlays.ContainsKey((status, unitIndex));
    }
}
