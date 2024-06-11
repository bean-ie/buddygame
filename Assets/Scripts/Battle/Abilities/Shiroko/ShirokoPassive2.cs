using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShirokoPassive2 : PassiveAbility
{
    public ShirokoPassive2()
    {
        abilityName = "Appreciation";
        abilityIcon = Resources.Load<Sprite>("Sprites/peterholder");
        abilityDescription = "For every buff Shiroko has, increase Shiroko's ATK by 10%.";
        abilityType = new AbilityType[] { AbilityType.passive, AbilityType.affectsself, AbilityType.buffing, AbilityType.singletarget };
        effectIDs = new int[] { 3 };
    }
}
