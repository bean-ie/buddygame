using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockDoT : StatusEffect
{
    public ShockDoT()
    {
        statusName = "Shock";
        statusDescription = "This target is shocked. Shocked enemies will take damage everytime they're hit, and their damage dealt will be reduced.";
        statusIcon = Resources.Load<Sprite>("Sprites/Status Effects/Icon_Shock");
        statusType = StatusType.debuff;
        statusEffectIDs = new int[] { 6 };
    }
}
