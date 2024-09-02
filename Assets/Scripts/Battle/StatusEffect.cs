using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatusEffect
{
    public string statusName, statusDescription;
    public Sprite statusIcon;
    public StatusType statusType;
    public int[] statusEffectIDs;
    public GameObject overlay;

    public bool stackable = false;
    public int maxStacks = 1;
    public bool refreshable = true;
    public bool hidden = false;
    public bool permanent = false;
    public bool removable = true;

    public virtual void AddBonuses(BattleUnit unit) { }
}

public enum StatusType
{
    buff,
    debuff,
    neutral
}
