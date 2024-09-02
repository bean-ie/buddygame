using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShirokoDEFIgnoreBuff : StatusEffect
{
    public ShirokoDEFIgnoreBuff()
    {
        statusName = "Action";
        statusDescription = "This unit ignores 40% of enemies' DEF.";
        statusIcon = Resources.Load<Sprite>("Sprites/Status Effects/Icon_ATK_Up");
        statusType = StatusType.buff;
        stackable = false;
        maxStacks = 1;
    }

    public override void AddBonuses(BattleUnit unit)
    {
        unit.DEFIgnore.AddFlatBonus(40);
    }
}
