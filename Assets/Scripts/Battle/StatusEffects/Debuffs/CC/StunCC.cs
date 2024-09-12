using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StunCC : StatusEffect
{
    public StunCC()
    {
        statusName = "Stun";
        statusDescription = "This target is stunned.";
        statusIcon = Resources.Load<Sprite>("Sprites/Status Effects/Icon_Imprisonment");
        overlay = Resources.Load<GameObject>("Prefabs/Overlays/StunOverlay");
        statusType = StatusType.debuff;
        skipTurn = true;
    }
}
