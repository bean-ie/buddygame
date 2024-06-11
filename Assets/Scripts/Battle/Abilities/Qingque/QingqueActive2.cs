using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QingqueActive2 : Ability
{
    public QingqueActive2()
    {
        abilityName = "A Scoop of Moon";
        abilityIcon = Resources.Load<Sprite>("Sprites/Abilities/Qingque/AScoopOfMoon");
        abilityDescription = "Has a 75% chance to restore a small amount of MP. If this doesn't succeed, end Qingque's turn. If it succeeds, this skill will not end Qingque's turn.";
        abilityType = new AbilityType[4] { AbilityType.active, AbilityType.singletarget, AbilityType.buffing, AbilityType.affectsself };
        abilityTargetsAlly = false;
        MPcost = 0;
        TPgain = 0;
        dontEndTurn = true;
        noTarget = true;
    }

    public override void UseAbility(AbilityUsage usage)
    {
        if (Random.Range(0f, 1f) < 0.75f)
        {
            usage.user.RegenerateMP(40);
            dontEndTurn = true;
        }
        else
        {
            dontEndTurn = false;
        }
    }
}
