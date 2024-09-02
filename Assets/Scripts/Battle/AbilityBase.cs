using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityBase
{
    public string abilityName, abilityDescription;
    [SerializeReference]
    public Sprite abilityIcon;
    public AbilityType[] abilityType;
}
