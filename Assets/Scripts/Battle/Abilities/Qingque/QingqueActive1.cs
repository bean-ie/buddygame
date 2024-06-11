using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QingqueActive1 : Ability
{
    public QingqueActive1()
    {
        abilityName = "Flower Pick";
        abilityIcon = Resources.Load<Sprite>("Sprites/Abilities/Qingque/FlowerPick");
        abilityDescription = "Has a 50% chance to deal damage to a random enemy. If this doesn't succeed, consume MP. Using this skill will not end Qingque's turn.";
        abilityType = new AbilityType[3] { AbilityType.active, AbilityType.singletarget, AbilityType.damaging };
        abilityTargetsAlly = false;
        MPcost = 40;
        TPgain = 0;
        dontEndTurn = true;
        noTarget = true;
    }

    public override void UpdateAbilityInfo()
    {
        MPcost = 40;
    }

    public override void UseAbility(AbilityUsage usage)
    {
        if (Random.Range(0f, 1f) < 0.5f)
        {
            MPcost = 0;
            int selectedUnit = usage.battle.GetAliveEnemiesIndex()[Random.Range(0, usage.battle.AliveEnemyCount())];
            usage.battle.GetUnitAt(selectedUnit).DealDamage(new Damage(usage.user.MATK.current * 1, usage.user));
        }
        else
        {
            MPcost = 40;
        }
    }
}
