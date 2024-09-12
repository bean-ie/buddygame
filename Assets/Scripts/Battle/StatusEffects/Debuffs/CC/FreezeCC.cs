using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeCC : StatusEffect
{
    public FreezeCC()
    {
        statusName = "Freeze";
        statusDescription = "This target is frozen. Frozen enemies will become stronger after thawing.";
        statusIcon = Resources.Load<Sprite>("Sprites/Status Effects/Icon_Frozen");
        overlay = Resources.Load<GameObject>("Prefabs/Overlays/IceOverlay");
        statusType = StatusType.debuff;
        skipTurn = true;
    }
}
