using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UnitResource
{
    public int baseMax, current, max, flatBonus, multiplierBonus;

    public void AddFlatBonus(int amount)
    {
        flatBonus += amount;
    }

    public void AddMultiplierBonus(int amount)
    {
        multiplierBonus += amount;
    }

    public void ResetBonuses()
    {
        flatBonus = 0;
        multiplierBonus = 0;
    }

    public void ResetStat()
    {
        ResetBonuses();
        UpdateStat();
        current = max;
    }

    public void UpdateStat()
    {
        max = Mathf.CeilToInt((float)baseMax * (1 + (float)multiplierBonus/100f) + flatBonus);
        current = Mathf.Min(current, max);
    }
}

[Serializable]
public class UnitStat
{
    public int baseStat, current, flatBonus, multiplierBonus;

    public void AddFlatBonus(int amount)
    {
        flatBonus += amount;
    }

    public void AddMultiplierBonus(int amount)
    {
        multiplierBonus += amount;
    }

    public void ResetBonuses()
    {
        flatBonus = 0;
        multiplierBonus = 0;
    }

    public void UpdateStat()
    {
        current = Mathf.CeilToInt(baseStat * (1 + multiplierBonus / 100f) + flatBonus);
    }
}