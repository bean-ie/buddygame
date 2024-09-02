using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShirokoPEffect1 : PassiveEffect
{
    public override void GlobalTurnStarts(BattleUnit user, Battle battle)
    {
        foreach (BattleUnit unit in battle.GetAllUnits())
        {
            if (unit.isEnemy != user.isEnemy)
            {
                unit.ApplyStatus(1, 1, user);
            }
        }
    }

    public override void UnitTakesDamage(BattleUnit caller, BattleUnit damaged, Battle battle, Damage damage)
    {
        if (caller == damage.source) return;
        AppliedStatus status = Helper.GetUnitStatus(damaged, 1);
        if (status != null)
        {
            damaged.RemoveStatus(status);
            battle.AddFuaToQueue(new FUAUsage(0, battle, caller, battle.GetIndexOf(damaged)));
        }
    }
}