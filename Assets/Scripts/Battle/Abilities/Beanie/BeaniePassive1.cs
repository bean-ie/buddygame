using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeaniePassive1 : PassiveAbility
{
    public BeaniePassive1()
    {
        abilityName = "Blessing of the Merciful Medicus";
        abilityIcon = Resources.Load<Sprite>("Sprites/peterholder");
        abilityDescription = "When Beanie is hit, they heal themselves for a % of Beanie's Max HP.";
        abilityType = new AbilityType[3] { AbilityType.passive, AbilityType.singletarget, AbilityType.healing };
        effectIDs = new int[1] { 1 };
    }
}
