using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppliedStatus
{
    public int statusID;
    public int stacks;
    public int remainingTurnDuration;
    public BattleUnit applier;

    public AppliedStatus(int id, int turnDuration, BattleUnit applier)
    {
        statusID = id;
        remainingTurnDuration = turnDuration;
        stacks = 1;
        this.applier = applier;
    }
}