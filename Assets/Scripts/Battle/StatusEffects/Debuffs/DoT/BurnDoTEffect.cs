using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BurnDoTEffect : PassiveEffect
{
    public override void UserTurnStarts(BattleUnit user, Battle battle)
    {
        AppliedStatus status = user.appliedStatuses.First(x => x.statusID == 9);

        foreach (BattleUnit unit in battle.GetAllUnits().Where(x => x.isEnemy == user.isEnemy))
        {
            if (Random.Range(0, 100) <= 20) unit.ApplyStatus(9, 1, status.applier);
        }

        int baseDamage = Mathf.Max(status.applier.ATK.current, status.applier.MATK.current);
        user.DealDamage(new Damage(baseDamage * 0.5f, status.applier));
    }
}
