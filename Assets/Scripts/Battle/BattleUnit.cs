using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

[Serializable]
public abstract class BattleUnit
{
    public bool isEnemy;

    public UnitResource HP = new UnitResource();
    public UnitResource MP = new UnitResource();
    public UnitResource TP = new UnitResource();
    public UnitStat ATK = new UnitStat();
    public UnitStat MATK = new UnitStat();
    public UnitStat DEF = new UnitStat();
    public UnitStat MDEF = new UnitStat();
    public UnitStat CR = new UnitStat();
    public UnitStat CDMG = new UnitStat();

    public bool isDead = false;
    public List<AppliedStatus> appliedStatuses = new List<AppliedStatus>();

    public void SetupStats()
    {
        HP.baseMax = GetBaseCharacter().baseHP;
        HP.ResetStat();
        MP.baseMax = GetBaseCharacter().baseMP;
        MP.ResetStat();
        TP.baseMax = GetBaseCharacter().baseTP;
        TP.ResetStat();
        ATK.baseStat = GetBaseCharacter().baseATK;
        ATK.UpdateStat();
        MATK.baseStat = GetBaseCharacter().baseMATK;
        MATK.UpdateStat();
        DEF.baseStat = GetBaseCharacter().baseDEF;
        DEF.UpdateStat();
        MDEF.baseStat = GetBaseCharacter().baseMDEF;
        MDEF.UpdateStat();
        CR.baseStat = GetBaseCharacter().baseCR;
        CR.UpdateStat();
        CDMG.baseStat = GetBaseCharacter().baseCDMG;
        CDMG.UpdateStat();
    }

    public void DealDamage(Damage damage)
    {
        // Modify the damage from stats and shit

        if (damage.amount < 0) return;

        DealDamageUnmodified(damage.amount + damage.bonusAmount);

        foreach (int passiveID in GetBaseCharacter().passiveAbilityIDs)
        {
            foreach (int effectID in GameManager.instance.idManager.passives[passiveID].effectIDs)
            {
                GameManager.instance.idManager.effects[effectID].UserTakesDamage(damage, this, GameManager.instance.battleManager.currentBattle);
            }
        }
        GameManager.instance.battleManager.UnitTakesDamage(this, damage);
    }

    public void Heal(int amount)
    {
        // Modify the heal and shit

        if (amount <= 0) return;

        DealDamageUnmodified(-amount);
    }

    public void ConsumeMP(int amount)
    {
        MP.current = Mathf.Clamp(MP.current - amount, 0, MP.max);
    }

    public void RegenerateMP(int amount)
    {
        MP.current = Mathf.Clamp(MP.current + amount, 0, MP.max);
    }

    public void ConsumeTP(int amount)
    {
        TP.current = Mathf.Clamp(TP.current - amount, 0, TP.max);
    }

    public void RegenerateTP(int amount)
    {
        TP.current = Mathf.Clamp(TP.current + amount, 0, TP.max);
    }

    public void DealDamageUnmodified(int damage)
    {
        if (isDead) return;
        HP.current = Mathf.Clamp(HP.current - damage, 0, HP.max);
        if (HP.current == 0) isDead = true; 
        string damageText = (damage > 0 ? "-" : "+") + MathF.Abs(damage);
        Color damageColor = (damage > 0 ? Color.red : Color.green);
        GameManager.instance.battleManager.SpawnFloatingTextOnUnit(this, damageText, damageColor);
        if (!isDead)
        GameManager.instance.battleManager.FlashBattleSprite(this, damageColor, 0f, 0f, 1f);
    }

    public void ApplyStatus(int id, int turnDuration, bool refreshDuration = true)
    {
        Color textColor;
        switch (Helper.GetStatus(id).statusType)
        {
            case StatusType.buff: textColor = Color.green; break;
            case StatusType.debuff: textColor = Color.red; break;
            default: textColor = Color.white; break;
        }
        for (int i = 0; i < appliedStatuses.Count; i++)
        {
            if (appliedStatuses[i].statusID == id)
            {
                if (refreshDuration)
                {
                    appliedStatuses[i].remainingTurnDuration = turnDuration;
                }
                if (Helper.GetStatus(id).stackable && appliedStatuses[i].stacks < Helper.GetStatus(id).maxStacks)
                {
                    appliedStatuses[i].stacks++;
                }
                UpdateStatuses();
                GameManager.instance.battleManager.SpawnFloatingTextOnUnit(this, "+" + Helper.GetStatus(id).statusName, textColor);
                return;
            }
        }
        AppliedStatus status = new AppliedStatus(id, turnDuration);
        appliedStatuses.Add(status);
        UpdateStatuses();
        GameManager.instance.battleManager.SpawnFloatingTextOnUnit(this, Helper.GetStatus(id).statusName, textColor);
    }

    public void UpdateStatuses(bool callPassives = true)
    {
        appliedStatuses.RemoveAll(x => x.remainingTurnDuration <= 0 && !Helper.GetStatus(x.statusID).permanent);
        HP.ResetBonuses();
        MP.ResetBonuses();
        TP.ResetBonuses();
        ATK.ResetBonuses();
        MATK.ResetBonuses();
        DEF.ResetBonuses();
        MDEF.ResetBonuses();
        CR.ResetBonuses();
        CDMG.ResetBonuses();
        foreach (AppliedStatus status in appliedStatuses)
        {
            for (int i = 0; i < status.stacks; i++)
            {
                Helper.GetStatus(status.statusID).AddBonuses(this);
            }
        }
        HP.UpdateStat();
        MP.UpdateStat();
        TP.UpdateStat();
        ATK.UpdateStat();
        MATK.UpdateStat();
        DEF.UpdateStat();
        MDEF.UpdateStat();
        CR.UpdateStat();
        CDMG.UpdateStat();
        if (!callPassives) return;
        foreach (int passiveID in GetBaseCharacter().passiveAbilityIDs)
        {
            foreach (int effectID in GameManager.instance.idManager.passives[passiveID].effectIDs)
            {
                GameManager.instance.idManager.effects[effectID].UserBuffsUpdate(this);
            }
        }
    }   

    public void CountdownStatuses()
    {
        foreach (AppliedStatus status in appliedStatuses)
        {
            if (!Helper.GetStatus(status.statusID).permanent)
                status.remainingTurnDuration--;
        }
        UpdateStatuses();
    }

    public void RemoveStatus(AppliedStatus status)
    {
        if (Helper.GetStatus(status.statusID).removable)
        {
            appliedStatuses.Remove(status);
        }
        else return;
    }

    public UnitSO GetBaseCharacter()
    {
        if (isEnemy)
        {
            EnemyUnit enemy = (EnemyUnit)this;
            return enemy.baseCharacter;
        }
        else
        {
            CharacterUnit character = (CharacterUnit)this;
            return character.baseCharacter;
        }
    }
}
