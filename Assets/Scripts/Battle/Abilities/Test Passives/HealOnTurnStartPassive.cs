using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealOnTurnStartPassive : PassiveAbility
{
    public HealOnTurnStartPassive()
    {
        abilityName = "Heal on turn start passive";
        abilityIcon = Resources.Load<Sprite>("Sprites/peterholder");
        abilityDescription = "Heals you whenever your turn starts";
        abilityType = new AbilityType[3] { AbilityType.passive, AbilityType.singletarget, AbilityType.healing };
        effectIDs = new int[1] { 0 };
    }
}
