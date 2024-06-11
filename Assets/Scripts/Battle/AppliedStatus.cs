using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppliedStatus
{
    public int statusID;
    public int stacks;
    public int remainingTurnDuration;

    public AppliedStatus(int id, int turnDuration)
    {
        statusID = id;
        remainingTurnDuration = turnDuration;
        stacks = 1;
    }
}