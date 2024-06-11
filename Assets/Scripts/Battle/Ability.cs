using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : AbilityBase
{
    public bool abilityTargetsAlly;
    public bool noTarget;
    public AbilityAnimationTarget abilityAnimationTarget = AbilityAnimationTarget.noMove;
    public int MPcost, TPcost, TPgain;
    public bool dontEndTurn = false;

    public abstract void UseAbility(AbilityUsage usage);

    public virtual void UpdateAbilityInfo() { }

    public virtual bool IsAvailable(BattleUnit unit)
    {
        return true;
    }
}
