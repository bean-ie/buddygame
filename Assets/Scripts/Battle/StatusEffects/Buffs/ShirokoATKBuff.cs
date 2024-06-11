using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShirokoATKBuff : StatusEffect
{
    public ShirokoATKBuff()
    {
        statusName = "Appreciation";
        statusDescription = "Increases ATK by 10% per stack.";
        statusIcon = Resources.Load<Sprite>("Sprites/Status Effects/Icon_ATK_Up");
        statusType = StatusType.buff;
        stackable = true;
        permanent = true;
        removable = true;
        maxStacks = 99;
    }

    public override void AddBonuses(BattleUnit unit)
    {
        unit.ATK.AddMultiplierBonus(10);
    }
}
