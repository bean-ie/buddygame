using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QingqueActive4 : Ability
{
    public QingqueActive4()
    {
        abilityName = "Cherry on Top!";
        abilityIcon = Resources.Load<Sprite>("Sprites/Abilities/Qingque/CherryOnTop");
        abilityDescription = "Choose an enemy. Three random things can happen with equal chance:" +
            "\r\nDeal incredible damage to that enemy. Does not end Qingque's turn." +
            "\r\nConsume MP. Does not end Qingque's turn." +
            "\r\nEnd Qingque's turn.";
        abilityType = new AbilityType[3] { AbilityType.active, AbilityType.singletarget, AbilityType.damaging };
        abilityTargetsAlly = false;
        MPcost = 60;
        TPgain = 0;
        dontEndTurn = true;
        noTarget = false;
    }

    public override void UpdateAbilityInfo()
    {
        MPcost = 60;
    }

    public override void UseAbility(AbilityUsage usage)
    {
        switch(Random.Range(0,3))
        {
            case 0:
                MPcost = 0;
                usage.battle.GetUnitAt(usage.selectedUnit).DealDamage(new Damage(usage.user.MATK.current * 2, usage.user));
                dontEndTurn = true;
                break;
            case 1:
                MPcost = 60;
                dontEndTurn = true;
                break;
            case 2:
                MPcost = 0;
                dontEndTurn = false;
                break;
        }
    }
}
