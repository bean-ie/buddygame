using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShirokoDebuff1 : StatusEffect
{
    public ShirokoDebuff1()
    {
        statusName = "Marked";
        statusDescription = "The enemy is marked. Shiroko will unleash a follow up attack to this target if an ally hits the target, consuming the mark.";
        statusIcon = Resources.Load<Sprite>("Sprites/Status Effects/Icon_ATK_Up");
        statusType = StatusType.debuff;
        stackable = false;
        permanent = false;
        refreshable = true;
        removable = true;
        maxStacks = 1;
    }
}
