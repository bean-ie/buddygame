using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QingqueActive5 : Ability
{
    public QingqueActive5()
    {
        abilityName = "Bide Time";
        abilityIcon = Resources.Load<Sprite>("Sprites/Abilities/Qingque/BideTime");
        abilityDescription = "Restore a major amount of MP. End Qingque's turn.";
        abilityType = new AbilityType[3] { AbilityType.active, AbilityType.singletarget, AbilityType.buffing };
        abilityTargetsAlly = false;
        MPcost = 0;
        TPgain = 0;
        dontEndTurn = false;
        noTarget = true;
    }

    public override void UseAbility(AbilityUsage usage)
    {
        usage.user.RegenerateMP(200);
    }
}
