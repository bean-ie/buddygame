using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NerfcentPassive : PassiveAbility
{
    public NerfcentPassive()
    {
        abilityName = "Foreign Technique";
        abilityIcon = Resources.Load<Sprite>("Sprites/peterholder");
        abilityDescription = "Nerfcent's turn doesn't end until he runs out of MP. He regenerates all his MP on turn start.";
        abilityType = new AbilityType[] { AbilityType.passive, AbilityType.singletarget, AbilityType.buffing };
        effectIDs = new int[] { 4 };
    }
}
