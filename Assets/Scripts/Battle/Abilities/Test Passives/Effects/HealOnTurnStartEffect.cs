using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealOnTurnStartEffect : PassiveEffect
{
    int healAmount;
    public HealOnTurnStartEffect(int _healAmount)
    {
        healAmount = _healAmount;
    }

    public override void UserTurnStarts(BattleUnit user, Battle battle)
    {
        user.DealDamageUnmodified(-healAmount);
    }
}
