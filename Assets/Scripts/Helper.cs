using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour
{
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
}
