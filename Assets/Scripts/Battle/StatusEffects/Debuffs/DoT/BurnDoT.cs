using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnDoT : StatusEffect
{
    public BurnDoT()
    {
        statusName = "Burn";
        statusDescription = "This target is burning. Burn will have a chance to spread to other targets on turn start, " +
            "and also increases damage taken of all affected targets.";
        statusIcon = Resources.Load<Sprite>("Sprites/Status Effects/Icon_Burn");
        overlay = Resources.Load<GameObject>("Prefabs/Overlays/BurnOverlay");
        statusType = StatusType.debuff;
        statusEffectIDs = new int[] { 5 };
    }
}