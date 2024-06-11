using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanieAttackAction : Ability
{
    public BeanieAttackAction()
    {
        abilityName = "I bear no weapon";
        abilityIcon = Resources.Load<Sprite>("Sprites/peterholder");
        abilityDescription = "Beanie pats an ally, healing them for a % of Beanie's Current HP.";
        abilityType = new AbilityType[3] { AbilityType.active, AbilityType.singletarget, AbilityType.healing };
        abilityTargetsAlly = true;
        MPcost = -50;
        TPgain = 30;
    }

    public override void UseAbility(AbilityUsage usage)
    {
        BattleUnit selectedUnit = usage.battle.GetUnitAt(usage.selectedUnit);
        if (selectedUnit.isEnemy == usage.user.isEnemy)
        {
            selectedUnit.Heal(Mathf.CeilToInt(usage.user.HP.current * 0.4f));
        }
    }
}
