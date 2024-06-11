using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanieEffect1 : PassiveEffect
{
    public override void UserTakesDamage(Damage damage, BattleUnit user, Battle battle)
    {
        user.Heal(Mathf.CeilToInt(user.HP.max * 0.1f));
    }
}
