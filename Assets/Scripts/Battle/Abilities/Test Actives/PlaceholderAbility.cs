using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceholderAbility : Ability
{
    public PlaceholderAbility()
    {
        abilityName = "Placeholder Ability";
        abilityIcon = Resources.Load<Sprite>("Sprites/peterholder");
        abilityDescription = "Deals damage to an enemy. Fun.";
        abilityType = new AbilityType[3] { AbilityType.active, AbilityType.singletarget, AbilityType.damaging };
        abilityTargetsAlly = false;
        abilityAnimationTarget = AbilityAnimationTarget.toTarget;
    }

    public override void UseAbility(AbilityUsage usage)
    {
        BattleUnit selectedUnit = usage.battle.GetUnitAt(usage.selectedUnit);
        selectedUnit.DealDamage(new Damage(100, usage.user));
    }
}
