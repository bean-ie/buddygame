using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NerfcentPEffect : PassiveEffect
{
    public override void UserTurnStarts(BattleUnit user, Battle battle)
    {
        user.RegenerateMP(user.MP.max - user.MP.current);
    }
}
