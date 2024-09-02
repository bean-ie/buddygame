using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShirokoUlt1 : Ability
{
    public ShirokoUlt1()
    {
        abilityName = "Action   ";
        abilityIcon = Resources.Load<Sprite>("Sprites/peterholder");
        abilityDescription = "Shiroko gains a buff that causes her to ignore 40% of enemies' DEF for 3 turns.";
        abilityType = new AbilityType[] { AbilityType.active, AbilityType.singletarget, AbilityType.affectsself, AbilityType.buffing };
        noTarget = true;
        TPcost = 100;
    }

    public override void UseAbility(AbilityUsage usage)
    {
        usage.user.ApplyStatus(8, 3, usage.user);
    }
}
