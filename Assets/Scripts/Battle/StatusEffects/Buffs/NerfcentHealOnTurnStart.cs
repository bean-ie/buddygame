using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NerfcentHealOnTurnStart : StatusEffect
{
    public NerfcentHealOnTurnStart()
    {
        statusName = "Purify";
        statusDescription = "This unit will heal at the start of the turn.";
        statusIcon = Resources.Load<Sprite>("Sprites/peterholder");
        statusType = StatusType.buff;
        statusEffectIDs = new int[] { 8 };
    }
}
