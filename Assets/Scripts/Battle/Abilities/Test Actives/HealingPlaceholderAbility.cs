using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPlaceholderAbility : Ability
{
    public HealingPlaceholderAbility()
    {
        abilityName = "Healing Ability";
        abilityIcon = Resources.Load<Sprite>("Sprites/peterholder");
        abilityDescription = "Heals an ally. Fun.";
        abilityType = new AbilityType[3] { AbilityType.active, AbilityType.singletarget, AbilityType.healing };
        abilityTargetsAlly = true;
    }

    public override void UseAbility(AbilityUsage usage)
    {
        BattleUnit selectedUnit = usage.battle.GetUnitAt(usage.selectedUnit);
        if (!selectedUnit.isEnemy)
        {
            selectedUnit.Heal(100);
        }
    }
}
