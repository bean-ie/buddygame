using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QingqueActive3 : Ability
{
    public QingqueActive3()
    {
        abilityName = "Game Solitaire";
        abilityIcon = Resources.Load<Sprite>("Sprites/Abilities/Qingque/GameSolitaire");
        abilityDescription = "Has a 50% chance to give Qingque a stack of a MATK buff. If this doesn't succeed, consume MP. Using this skill will not end Qingque's turn.";
        abilityType = new AbilityType[4] { AbilityType.active, AbilityType.singletarget, AbilityType.buffing, AbilityType.affectsself };
        abilityTargetsAlly = false;
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
            usage.user.ApplyStatus(0, 2);
            int stacks = -1;
            foreach (AppliedStatus s in usage.user.appliedStatuses)
            {
                if (s.statusID == 0)
                {
                    stacks = s.stacks;
                    break;
                }
            }
        }
        else
        {
            MPcost = 40;
        }
    }
}
