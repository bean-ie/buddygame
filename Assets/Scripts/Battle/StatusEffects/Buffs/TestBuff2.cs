using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBuff2 : StatusEffect
{
    public TestBuff2()
    {
        statusName = "Test Buff 1";
        statusDescription = "Increases MP by 100.";
        statusIcon = Resources.Load<Sprite>("Sprites/peterholder");
        statusType = StatusType.buff;
        stackable = false;
        maxStacks = 1;
    }

    public override void AddBonuses(BattleUnit unit)
    {
        unit.MP.AddFlatBonus(100);
    }
}
