using UnityEngine;

public class ShirokoDebuffs21 : StatusEffect
{
    public ShirokoDebuffs21()
    {
        statusName = "Analyzed";
        statusDescription = "Shiroko's Follow-Up Attacks against Analyzed enemies deal bonus damage.";
        statusIcon = Resources.Load<Sprite>("Sprites/peterholder");
        statusType = StatusType.debuff;
        stackable = false;
        permanent = false;
        refreshable = true;
        removable = true;
        maxStacks = 1;
    }
}

public class ShirokoDebuffs22 : StatusEffect
{
    public ShirokoDebuffs22()
    {
        statusName = "Altered";
        statusDescription = "Shiroko's Follow-Up Attacks against Altered enemies have increased Crit Rate and slightly increased Crit Damage.";
        statusIcon = Resources.Load<Sprite>("Sprites/peterholder");
        statusType = StatusType.debuff;
        stackable = false;
        permanent = false;
        refreshable = true;
        removable = true;
        maxStacks = 1;
    }
}

public class ShirokoDebuffs23 : StatusEffect
{
    public ShirokoDebuffs23()
    {
        statusName = "Attached";
        statusDescription = "Shiroko's Follow-Up Attacks against Attached enemies will deal small bonus damage to all enemies on the field.";
        statusIcon = Resources.Load<Sprite>("Sprites/peterholder");
        statusType = StatusType.debuff;
        stackable = false;
        permanent = false;
        refreshable = true;
        removable = true;
        maxStacks = 1;
    }
}

