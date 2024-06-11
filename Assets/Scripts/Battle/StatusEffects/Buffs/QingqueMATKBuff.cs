using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QingqueMATKBuff : StatusEffect
{
    public QingqueMATKBuff()
    {
        statusName = "Game Solitaire";
        statusDescription = "Increases MATK by 50 per stack.";
        statusIcon = Resources.Load<Sprite>("Sprites/Status Effects/Icon_ATK_Up");
        statusType = StatusType.buff;
        stackable = true;
        maxStacks = 99;
    }

    public override void AddBonuses(BattleUnit unit)
    {
        Debug.Log("adding flat matk");
        unit.MATK.AddFlatBonus(50);
    }
}
