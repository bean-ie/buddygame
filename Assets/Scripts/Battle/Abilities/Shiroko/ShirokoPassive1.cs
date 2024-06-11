using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShirokoPassive1 : PassiveAbility
{
    public ShirokoPassive1()
    {
        abilityName = "Target Practice";
        abilityIcon = Resources.Load<Sprite>("Sprites/peterholder");
        abilityDescription = "Shiroko's drone marks all enemies every turn. When allies attack a marked enemy, Shiroko will perform a Follow-Up Attack, dealing damage to the target and adjacent enemies.";
        abilityType = new AbilityType[3] { AbilityType.passive, AbilityType.aoe, AbilityType.debuffing };
        effectIDs = new int[1] { 2 };
    }
}
