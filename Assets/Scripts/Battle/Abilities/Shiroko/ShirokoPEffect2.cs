using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShirokoPEffect2 : PassiveEffect
{
    public override void UserBuffsUpdate(BattleUnit user)
    {
        int buffsCount = 0;
        bool hasShirokoBuff = false;
        foreach (AppliedStatus status in user.appliedStatuses)
        {
            if (status.statusID == 2)
            {
                hasShirokoBuff = true;
                continue;
            }
            if (Helper.GetStatus(status.statusID).statusType == StatusType.buff)
            {
                buffsCount++;
            }
        }
        if (!hasShirokoBuff && buffsCount > 0)
        {
            user.ApplyStatus(2, 1, user);
        }
        foreach (AppliedStatus status in user.appliedStatuses)
        {
            if (status.statusID == 2) status.stacks = buffsCount;
        }
        user.UpdateStatuses(false);
    }
}
