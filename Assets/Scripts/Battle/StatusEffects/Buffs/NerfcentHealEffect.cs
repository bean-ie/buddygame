using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NerfcentHealEffect : PassiveEffect
{
    public override void UserTurnStarts(BattleUnit user, Battle battle)
    {
        user.Heal(Mathf.CeilToInt(user.HP.max * 0.2f));
    }
}
