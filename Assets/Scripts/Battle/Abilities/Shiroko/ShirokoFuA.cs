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
        for (int i = -1; i <= 1; i++)
        {
            if (usage.selectedUnit + i >= usage.battle.GetAllUnits().Count) continue;
            if (usage.battle.GetUnitAt(usage.selectedUnit + i).isEnemy == usage.user.isEnemy) continue;
            if (usage.battle.GetUnitAt(usage.selectedUnit + i).HasStatus(7))
            {
                foreach (BattleUnit unit in usage.battle.GetAllUnits())
                {
                    if (unit.isEnemy != usage.user.isEnemy) unit.DealDamage(new Damage(usage.user.ATK.current * 0.25f, usage.user));
                }
            }

            Damage damage = null;
            int bonusCR = 0, bonusCDMG = 0, bonusDMG = 0;
            if (usage.battle.GetUnitAt(usage.selectedUnit + i).HasStatus(5))
            {
                bonusDMG = Mathf.CeilToInt(usage.user.ATK.current * 0.5f);
            }
            if (usage.battle.GetUnitAt(usage.selectedUnit + i).HasStatus(6))
            {
                bonusCR = 15;
                bonusCDMG = 25;
            }
            if (i == 0) damage = new Damage(usage.user.ATK.current * 1.5f, usage.user, bonusCDMG, bonusCR, bonusDMG);
            else damage = new Damage(usage.user.ATK.current, usage.user, bonusCDMG, bonusCR, bonusDMG);

            usage.battle.GetUnitAt(usage.selectedUnit + i).DealDamage(damage);
        }
    }
}
