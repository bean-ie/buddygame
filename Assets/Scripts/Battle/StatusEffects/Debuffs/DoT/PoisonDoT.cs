using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonDoT : StatusEffect
{
    public PoisonDoT()
    {
        statusName = "Poison";
        statusDescription = "This target is poisoned. Poison can be stacked up to 5 times, with every stack past 5 consuming itself to deal 2 ticks of damage.";
        statusIcon = Resources.Load<Sprite>("Sprites/Status Effects/Icon_Wind_Shear");
        statusType = StatusType.debuff;
        stackable = true;
        maxStacks = 5;
    }
}
