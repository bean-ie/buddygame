using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAllyAbility : Ability
{
    public DamageAllyAbility()
    {
        abilityName = "Damage Ally Ability";
        abilityIcon = Resources.Load<Sprite>("Sprites/peterholder");
        abilityDescription = "Damages an ally. You monster.";
        abilityType = new AbilityType[3] { AbilityType.active, AbilityType.singletarget, AbilityType.damaging };
        abilityTargetsAlly = true;
        abilityAnimationTarget = AbilityAnimationTarget.toCenter;
    }

    public override void UseAbility(AbilityUsage usage)
    {
        BattleUnit selectedUnit = usage.battle.GetUnitAt(usage.selectedUnit);
        if (!selectedUnit.isEnemy)
        {
            selectedUnit.DealDamage(new Damage(100, usage.user));
        }
    }
}
