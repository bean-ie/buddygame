using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInstaKill : Ability
{
    public TestInstaKill()
    {
        abilityName = "Instant Kill";
        abilityIcon = Resources.Load<Sprite>("Sprites/peterholder");
        abilityDescription = "Deals a shitload of damage to an enemy. Fun.";
        abilityType = new AbilityType[3] { AbilityType.active, AbilityType.singletarget, AbilityType.damaging };
        abilityTargetsAlly = false;
        abilityAnimationTarget = AbilityAnimationTarget.toTarget;
    }

    public override void UseAbility(AbilityUsage usage)
    {
        BattleUnit selectedUnit = usage.battle.GetUnitAt(usage.selectedUnit);
        selectedUnit.DealDamage(new Damage(1000000, usage.user));
    }
}
