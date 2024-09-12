using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class TestFreeze : Ability
{
    public TestFreeze()
    {
        abilityName = "Test Freeze";
        abilityIcon = Resources.Load<Sprite>("Sprites/peterholder");
        abilityDescription = "Freeze thy enemy";
        abilityType = new AbilityType[] { AbilityType.active, AbilityType.singletarget, AbilityType.crowdcontrol };
    }

    public override void UseAbility(AbilityUsage usage)
    {
        usage.battle.GetUnitAt(usage.selectedUnit).ApplyStatus(13, 1, usage.user);
    }
}
