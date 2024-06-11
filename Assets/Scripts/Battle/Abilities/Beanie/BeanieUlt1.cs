using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanieUlt1 : Ability
{
    public BeanieUlt1()
    {
        abilityName = "The Gift of Life";
        abilityIcon = Resources.Load<Sprite>("Sprites/peterholder");
        abilityDescription = "Beanie heals all allies for a high % of Beanie's Current HP and Cleanses 1 debuff from them.";
        abilityType = new AbilityType[3] { AbilityType.active, AbilityType.aoe, AbilityType.healing };
        abilityTargetsAlly = true;
        TPcost = 100;
    }

    public override void UseAbility(AbilityUsage usage)
    {
        for (int i = 0; i < GameManager.instance.teamManager.teamUnits.Length; i++)
        {
            if (usage.battle.GetUnitAt(i).isEnemy == usage.user.isEnemy)
                usage.battle.GetUnitAt(i).Heal(Mathf.CeilToInt(usage.user.HP.current * 0.6f));
        }
    }
}
