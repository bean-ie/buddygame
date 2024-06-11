using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PassiveEffect
{
    public virtual void UserTurnStarts(BattleUnit user, Battle battle) { }
    public virtual void UserTakesDamage(Damage damage, BattleUnit user, Battle battle) { }
    public virtual void GlobalTurnStarts(BattleUnit user, Battle battle) { }
    public virtual void UnitTakesDamage(BattleUnit caller, BattleUnit damaged, Battle battle, Damage damage) { }
    public virtual void UserBuffsUpdate(BattleUnit user) { }
}
