using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FUAUsage : AbilityUsage
{
    public int fuaID;

    public FUAUsage(int _fuaID, Battle _battle, BattleUnit _battleUnit, int _target)
    {
        fuaID = _fuaID;
        battle = _battle;
        user = _battleUnit;
        selectedUnit = _target;
    }
}
