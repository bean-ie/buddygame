using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseNerfcentSpell : Ability
{
    public override bool IsAvailable(BattleUnit unit)
    {
        MPcost = 1;

        if (unit.MP.current - 1 <= 0) this.dontEndTurn = false;
        else this.dontEndTurn = true;

        if (unit.MP.current > 0) return true;
        return false;
    }
}
