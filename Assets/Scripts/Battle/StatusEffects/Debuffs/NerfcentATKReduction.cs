using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NerfcentATKReduction : StatusEffect
{
    public NerfcentATKReduction()
    {
        statusName = "Depression";
        statusDescription = "Decreases MATK and ATK by 15%.";
        statusIcon = Resources.Load<Sprite>("Sprites/peterholder");
        statusType = StatusType.debuff;
    }
    public override void AddBonuses(BattleUnit unit)
    {
        unit.MATK.AddMultiplierBonus(-15);
        unit.ATK.AddMultiplierBonus(-15);
    }
}
