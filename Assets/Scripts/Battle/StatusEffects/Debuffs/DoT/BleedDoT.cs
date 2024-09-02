using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BleedDoT : StatusEffect
{
    public BleedDoT()
    {
        statusName = "Bleed";
        statusDescription = "This target is bleeding. They will receive massive damage when hit, and then have their healing reduced.";
        statusIcon = Resources.Load<Sprite>("Sprites/Status Effects/Icon_Bleed");
        statusType = StatusType.debuff;
        statusEffectIDs = new int[] { 7 };
    }
}
