using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FollowUpAttack : AbilityBase
{
    public float duration;

    public abstract void UnleashFUA(FUAUsage usage);
}