using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShockDoTEffect : PassiveEffect
{
    public override void UserTakesDamage(Damage damage, BattleUnit user, Battle battle)
    {
        AppliedStatus status = user.appliedStatuses.First(x => x.statusID == 10);
        int baseDamage = Mathf.Max(status.applier.ATK.current, status.applier.MATK.current);
        user.DealDamage(new Damage(baseDamage * 0.25f, status.applier));
    }
}
