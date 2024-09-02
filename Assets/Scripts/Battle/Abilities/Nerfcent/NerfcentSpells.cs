using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NerfcentSpell1 : BaseNerfcentSpell
{
    public NerfcentSpell1()
    {
        abilityName = "Immolate";
        abilityIcon = Resources.Load<Sprite>("Sprites/peterholder");
        abilityDescription = "nerfcent hurls fireballs at the target and adjacent enemies, " +
            "dealing Magic damage with a small % chance of inflicting Burn on ememies hit, increased against the main target.";
        abilityType = new AbilityType[] { AbilityType.active, AbilityType.blast, AbilityType.debuffing };
    }

    public override void UseAbility(AbilityUsage usage)
    {
        for (int i = -1; i <= 1; i += 2)
        {
            if (usage.selectedUnit + i < 0 || usage.selectedUnit + i > usage.battle.GetAllUnits().Count) continue;
            if (usage.battle.GetUnitAt(usage.selectedUnit + i).isEnemy == usage.user.isEnemy) continue;
            usage.battle.GetUnitAt(usage.selectedUnit + i).DealDamage(new Damage(usage.user.MATK.current * 0.7f, usage.user));
            if (Random.Range(0, 100) <= 30) usage.battle.GetUnitAt(usage.selectedUnit + i).ApplyStatus(9, 1, usage.user);
        }
        usage.battle.GetUnitAt(usage.selectedUnit).DealDamage(new Damage(usage.user.MATK.current, usage.user));
        if (Random.Range(0, 100) <= 50) usage.battle.GetUnitAt(usage.selectedUnit).ApplyStatus(9, 1, usage.user);
    }
}

public class NerfcentSpell2 : BaseNerfcentSpell
{
    public NerfcentSpell2()
    {
        abilityName = "Condensate";
        abilityIcon = Resources.Load<Sprite>("Sprites/peterholder");
        abilityDescription = "nerfcent casts icicles under all enemies, dealing Magic damage to them with a small % chance to Freeze the enemies hit for 1 turn.";
        abilityType = new AbilityType[] { AbilityType.active, AbilityType.aoe, AbilityType.crowdcontrol };
    }

    public override void UseAbility(AbilityUsage usage)
    {
        for (int i = GameManager.instance.teamManager.teamUnits.Length; i < usage.battle.GetAllUnits().Count; i++)
        {
            usage.battle.GetUnitAt(i).DealDamage(new Damage(usage.user.MATK.current * 0.6f, usage.user));
            if (Random.Range(0, 100) <= 5) usage.battle.GetUnitAt(i).ApplyStatus(13, 1, usage.user);
        }
    }
}

public class NerfcentSpell3 : BaseNerfcentSpell
{
    public NerfcentSpell3()
    {
        abilityName = "Intoxicate";
        abilityIcon = Resources.Load<Sprite>("Sprites/peterholder");
        abilityDescription = "nerfcent creates a cloud of toxins around all enemies, dealing damage to them with a % chance to Poison all enemies for 2 turns.";
        abilityType = new AbilityType[] { AbilityType.active, AbilityType.aoe, AbilityType.debuffing };
    }

    public override void UseAbility(AbilityUsage usage)
    {
        for (int i = GameManager.instance.teamManager.teamUnits.Length; i < usage.battle.GetAllUnits().Count; i++)
        {
            usage.battle.GetUnitAt(i).DealDamage(new Damage(usage.user.ATK.current * 0.45f, usage.user));
            if (Random.Range(0, 100) <= 50) usage.battle.GetUnitAt(i).ApplyStatus(12, 2, usage.user);
        }
    }
}

public class NerfcentSpell4 : BaseNerfcentSpell
{
    public NerfcentSpell4()
    {
        abilityName = "Manipulate";
        abilityIcon = Resources.Load<Sprite>("Sprites/peterholder");
        abilityDescription = "nerfcent changes the shape of an enemy's bones, dealing Magic damage to them " +
            "with a % chance to inflict Bleed on the target for 2 turns.";
        abilityType = new AbilityType[] { AbilityType.active, AbilityType.singletarget, AbilityType.debuffing };
    }

    public override void UseAbility(AbilityUsage usage)
    {
        usage.battle.GetUnitAt(usage.selectedUnit).DealDamage(new Damage(usage.user.MATK.current * 1.1f, usage.user));
        if (Random.Range(0, 100) <= 40) usage.battle.GetUnitAt(usage.selectedUnit).ApplyStatus(11, 2, usage.user);
    }
}

public class NerfcentSpell5 : BaseNerfcentSpell
{
    public NerfcentSpell5()
    {
        abilityName = "Precipitate";
        abilityIcon = Resources.Load<Sprite>("Sprites/peterholder");
        abilityDescription = "nerfcent conjures a thunderstorm, dealing damage to all enemies. " +
            "The thunderstorm has a % chance to inflict Shock to all enemies hit for 2 turns.";
        abilityType = new AbilityType[] { AbilityType.active, AbilityType.aoe, AbilityType.debuffing };
    }

    public override void UseAbility(AbilityUsage usage)
    {
        for (int i = GameManager.instance.teamManager.teamUnits.Length; i < usage.battle.GetAllUnits().Count; i++)
        {
            usage.battle.GetUnitAt(i).DealDamage(new Damage(usage.user.ATK.current * 0.5f, usage.user));
            if (Random.Range(0, 100) <= 25) usage.battle.GetUnitAt(i).ApplyStatus(10, 2, usage.user);
        }
    }
}

public class NerfcentSpell6 : BaseNerfcentSpell
{
    public NerfcentSpell6()
    {
        abilityName = "Annihilate";
        abilityIcon = Resources.Load<Sprite>("Sprites/peterholder");
        abilityDescription = "nerfcent shapes the land and uses it to crush an enemy, dealing Magic damage to them " +
            "with a small % chance of Stunning the target for 1 turn.";
        abilityType = new AbilityType[] { AbilityType.active, AbilityType.singletarget, AbilityType.crowdcontrol };
    }

    public override void UseAbility(AbilityUsage usage)
    {
        usage.battle.GetUnitAt(usage.selectedUnit).DealDamage(new Damage(usage.user.MATK.current * 1.8f, usage.user));
        if (Random.Range(0, 100) <= 7) usage.battle.GetUnitAt(usage.selectedUnit).ApplyStatus(14, 1, usage.user);
    }
}

public class NerfcentSpell7 : BaseNerfcentSpell
{
    public NerfcentSpell7()
    {
        abilityName = "Weaken";
        abilityIcon = Resources.Load<Sprite>("Sprites/peterholder");
        abilityDescription = "nerfcent casts a spell on all enemies, causing their magic barrier to weaken and reducing their Magic DEF for 1 turn.";
        abilityType = new AbilityType[] { AbilityType.active, AbilityType.aoe, AbilityType.debuffing };
    }

    public override void UseAbility(AbilityUsage usage)
    {
        for (int i = GameManager.instance.teamManager.teamUnits.Length; i < usage.battle.GetAllUnits().Count; i++)
        {
            usage.battle.GetUnitAt(i).DealDamage(new Damage(usage.user.ATK.current * 0.1f, usage.user));
            //if (Random.Range(0, 100) <= 25) usage.battle.GetUnitAt(i).ApplyStatus(10, 2);
        }
    }
}

public class NerfcentSpell8 : BaseNerfcentSpell
{
    public NerfcentSpell8()
    {
        abilityName = "Expose";
        abilityIcon = Resources.Load<Sprite>("Sprites/peterholder");
        abilityDescription = "nerfcent casts a spell on all enemies, exposing their weaknesses and reducing their Effect RES.";
        abilityType = new AbilityType[] { AbilityType.active, AbilityType.aoe, AbilityType.debuffing };
    }

    public override void UseAbility(AbilityUsage usage)
    {
        for (int i = GameManager.instance.teamManager.teamUnits.Length; i < usage.battle.GetAllUnits().Count; i++)
        {
            usage.battle.GetUnitAt(i).DealDamage(new Damage(usage.user.ATK.current * 0.1f, usage.user));
            //if (Random.Range(0, 100) <= 25) usage.battle.GetUnitAt(i).ApplyStatus(10, 2);
        }
    }
}

public class NerfcentSpell9 : BaseNerfcentSpell
{
    public NerfcentSpell9()
    {
        abilityName = "Depression";
        abilityIcon = Resources.Load<Sprite>("Sprites/peterholder");
        abilityDescription = "nerfcent casts a spell on all enemies, reducing their ATK and Magic ATK for 3 turns.";
        abilityType = new AbilityType[] { AbilityType.active, AbilityType.aoe, AbilityType.debuffing };
    }

    public override void UseAbility(AbilityUsage usage)
    {
        for (int i = GameManager.instance.teamManager.teamUnits.Length; i < usage.battle.GetAllUnits().Count; i++)
        {
            usage.battle.GetUnitAt(i).DealDamage(new Damage(usage.user.ATK.current * 0.1f, usage.user));
            if (Random.Range(0, 100) <= 40) usage.battle.GetUnitAt(i).ApplyStatus(15, 2, usage.user);
        }
    }
}

public class NerfcentSpell10 : BaseNerfcentSpell
{
    public NerfcentSpell10()
    {
        abilityName = "Motivation";
        abilityIcon = Resources.Load<Sprite>("Sprites/peterholder");
        abilityDescription = "nerfcent motivates himself, increasing his Magic ATK until the end of his current turn.";
        abilityType = new AbilityType[] { AbilityType.active, AbilityType.affectsself, AbilityType.buffing, AbilityType.singletarget };
        noTarget = true;
    }

    public override void UseAbility(AbilityUsage usage)
    {   
        usage.user.ApplyStatus(3, 1, usage.user);
    }
}

public class NerfcentSpell11 : BaseNerfcentSpell
{
    public NerfcentSpell11()
    {
        abilityName = "Fortify";
        abilityIcon = Resources.Load<Sprite>("Sprites/peterholder");
        abilityDescription = "nerfcent casts defensive mana onto himself, increasing his DEF for 2 turns.";
        abilityType = new AbilityType[] { AbilityType.active, AbilityType.affectsself, AbilityType.buffing, AbilityType.singletarget };
        noTarget = true;
    }

    public override void UseAbility(AbilityUsage usage)
    {
        usage.user.ApplyStatus(4, 1, usage.user);
    }
}

public class NerfcentSpell12 : BaseNerfcentSpell
{
    public NerfcentSpell12()
    {
        abilityName = "Purify";
        abilityIcon = Resources.Load<Sprite>("Sprites/peterholder");
        abilityDescription = "nerfcent purifies himself with sacred incantation, removing 1 debuff from himself " +
            "and healing a small % of his Max HP at the start of the next 2 turns.";
        abilityType = new AbilityType[] { AbilityType.active, AbilityType.affectsself, AbilityType.healing, AbilityType.buffing, AbilityType.singletarget };
        noTarget = true;
    }

    public override void UseAbility(AbilityUsage usage)
    {
        List<AppliedStatus> appliedDebuffs = usage.user.appliedStatuses.Where(x => Helper.GetStatus(x.statusID).statusType == StatusType.debuff).ToList();
        if (appliedDebuffs.Count() > 0) usage.user.RemoveStatus(appliedDebuffs[Random.Range(0, appliedDebuffs.Count())]);

        usage.user.ApplyStatus(16, 2, usage.user);

        Debug.Log("yummers");
    }
}