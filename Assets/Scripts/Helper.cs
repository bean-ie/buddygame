using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class Helper : MonoBehaviour
{
    public static GameObject hoverMessagePrefab;
    public static float BezierBlend(float t)
    {
        return t * t * (3.0f - 2.0f * t);
    }

    public static Ability GetAbility(int id)
    {
        return GameManager.instance.idManager.abilities[id];
    }

    public static PassiveAbility GetPassiveAbility(int id)
    {
        return GameManager.instance.idManager.passives[id];
    }

    public static PassiveEffect GetEffect(int id)
    {
        return GameManager.instance.idManager.effects[id];
    }

    public static StatusEffect GetStatus(int id)
    {
        return GameManager.instance.idManager.statuses[id];
    }

    public static AppliedStatus GetUnitStatus(BattleUnit unit, int id)
    {
        foreach (AppliedStatus status in unit.appliedStatuses)
        {
            if (status.statusID == id) return status;
        }
        return null;
    }

    public static FollowUpAttack GetFUA(int id)
    {
        return GameManager.instance.idManager.fuas[id];
    }

    public static EnemySO GetSummonnableEnemy(int id)
    {
        return GameManager.instance.idManager.summonnableEnemies[id];
    }

    public static void ActivateTurnStartPassiveEffects()
    {
        if (GameManager.instance.battleManager.currentBattle == null) return;

        foreach (int passiveID in GameManager.instance.battleManager.currentBattle.GetCurrentActingUnit().GetBaseCharacter().passiveAbilityIDs)
        {
            foreach (int effectID in Helper.GetPassiveAbility(passiveID).effectIDs)
            {
                Helper.GetEffect(effectID).UserTurnStarts(GameManager.instance.battleManager.currentBattle.GetCurrentActingUnit(), GameManager.instance.battleManager.currentBattle);
            }
        }
        foreach (AppliedStatus appliedStatus in GameManager.instance.battleManager.currentBattle.GetCurrentActingUnit().appliedStatuses)
        {
            if (Helper.GetStatus(appliedStatus.statusID).statusEffectIDs == null) continue;
            foreach(int effectID in Helper.GetStatus(appliedStatus.statusID).statusEffectIDs)
            {
                Helper.GetEffect(effectID).UserTurnStarts(GameManager.instance.battleManager.currentBattle.GetCurrentActingUnit(), GameManager.instance.battleManager.currentBattle);
            }
        }
    }
}
