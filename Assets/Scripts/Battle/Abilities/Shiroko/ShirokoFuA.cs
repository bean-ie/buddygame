using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShirokoFuA : FollowUpAttack
{
    public ShirokoFuA()
    {
        duration = 1;
        abilityName = "Target Practice";
        abilityDescription = string.Empty;
        abilityIcon = null;
        abilityType = new AbilityType[] { AbilityType.blast, AbilityType.damaging };
    }

    public override void UnleashFUA(FUAUsage usage)
    {
        usage.battle.GetUnitAt(usage.selectedUnit).DealDamage(new Damage(usage.user.ATK.current * 1.5f, usage.user));
        for (int i = -1; i <= 1; i += 2)
        {
            if (usage.selectedUnit + i >= usage.battle.GetAllUnits().Count ||
                usage.selectedUnit + i <= 0) continue;
            if (usage.battle.GetUnitAt(usage.selectedUnit + i).isEnemy != usage.user.isEnemy)
            {
                usage.battle.GetUnitAt(usage.selectedUnit + i).DealDamage(new Damage(usage.user.ATK.current, usage.user));
            }
        }
    }
}
