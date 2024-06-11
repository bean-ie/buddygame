using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShirokoActive1 : Ability
{
    public ShirokoActive1()
    {
        abilityName = "Fire Support";
        abilityIcon = Resources.Load<Sprite>("Sprites/peterholder");
        abilityDescription = "Shiroko sends out her drone, applying Analyzed, Altered or Attached to all enemies";
        abilityType = new AbilityType[] { AbilityType.active, AbilityType.aoe, AbilityType.debuffing };
        abilityTargetsAlly = false;
        noTarget = true;
        MPcost = 50;
        TPgain = 10;
    }

    public override void UseAbility(AbilityUsage usage)
    {
        foreach (BattleUnit unit in usage.battle.GetAllUnits())
        {
            if (unit.isEnemy != usage.user.isEnemy)
            {
                switch (Random.Range(0, 3))
                {
                    case 0: unit.ApplyStatus(5, 1); break;
                    case 1: unit.ApplyStatus(6, 1); break;
                    case 2: unit.ApplyStatus(7, 1); break;
                }
            }
        }
    }
}
