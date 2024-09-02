using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSummonEnemy : Ability
{
    EnemySO enemytosummon;
    public TestSummonEnemy()
    {
        abilityName = "Summon Enemy";
        abilityIcon = Resources.Load<Sprite>("Sprites/peterholder");
        abilityDescription = "Summons an enemy.";
        abilityType = new AbilityType[] { AbilityType.active, AbilityType.field };
        abilityTargetsAlly = false;
        noTarget = true;
    }

    public override void UseAbility(AbilityUsage usage)
    {
        usage.battle.SummonEnemy(Helper.GetSummonnableEnemy(0));
    }
}
