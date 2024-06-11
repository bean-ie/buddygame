using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBuff : Ability
{
    public TestBuff()
    {
        abilityName = "Test Buff";
        abilityIcon = Resources.Load<Sprite>("Sprites/peterholder");
        abilityDescription = "Adds a buff to an ally for 2 turns. If they already have it, adds a different one.";
        abilityType = new AbilityType[3] { AbilityType.active, AbilityType.singletarget, AbilityType.buffing };
        abilityTargetsAlly = true;
        abilityAnimationTarget = AbilityAnimationTarget.noMove;
    }

    public override void UseAbility(AbilityUsage usage)
    {
        BattleUnit selectedUnit = usage.battle.GetUnitAt(usage.selectedUnit);
        bool hasBuff = false;
        foreach (AppliedStatus status in selectedUnit.appliedStatuses)
        {
            if (status.statusID == 3) hasBuff = true;
        }
        if (selectedUnit.isEnemy == usage.user.isEnemy)
        {
            if (!hasBuff) selectedUnit.ApplyStatus(3, 2);
            else selectedUnit.ApplyStatus(4, 2);
        }
    }
}
