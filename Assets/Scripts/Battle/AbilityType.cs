using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AbilityType
{
    active,
    passive,
    singletarget,
    blast,
    aoe,
    damaging,
    defensive,
    debuffing,
    buffing,
    healing,
    field,
    crowdcontrol,
    excludesself,
    affectsself
}

public enum AbilityAnimationTarget
{
    toTarget,
    toCenter,
    noMove
}
