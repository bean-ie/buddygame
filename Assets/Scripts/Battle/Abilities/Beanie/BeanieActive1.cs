using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanieActive1 : Ability
{
    public BeanieActive1()
    {
        abilityName = "Kindness of Abundance";
        abilityIcon = Resources.Load<Sprite>("Sprites/peterholder");
        abilityDescription = "Beanie pats an ally, healing them for a % of Beanie's Current HP, and heals adjacent allies for a smaller % of Beanie's Current HP.";
        abilityType = new AbilityType[3] { AbilityType.active, AbilityType.blast, AbilityType.healing };
        abilityTargetsAlly = true;
        MPcost = 40;
        TPgain = 40;
    }

    public override void UseAbility(AbilityUsage usage)
    {
        BattleUnit selectedUnit = usage.battle.GetUnitAt(usage.selectedUnit);
        if (selectedUnit.isEnemy == usage.user.isEnemy)
        {
            selectedUnit.Heal(Mathf.CeilToInt(usage.user.HP.current * 0.4f));
        }
        for (int i = -1; i <= 1; i+=2)
        {
            selectedUnit = usage.battle.GetUnitAt(usage.selectedUnit + i);
            if (selectedUnit.isEnemy == usage.user.isEnemy)
            {
                selectedUnit.Heal(Mathf.CeilToInt(usage.user.HP.current * 0.2f));
            }
        }
    }
}
