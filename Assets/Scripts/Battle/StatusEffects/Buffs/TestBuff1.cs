using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBuff1 : StatusEffect
{
    public TestBuff1()
    {
        statusName = "Test Buff 1";
        statusDescription = "Increases HP by 100.";
        statusIcon = Resources.Load<Sprite>("Sprites/peterholder");
        statusType = StatusType.buff;
        stackable = false;
        maxStacks = 1;
    }

    public override void AddBonuses(BattleUnit unit)
    {
        unit.HP.AddFlatBonus(100);
    }
}
