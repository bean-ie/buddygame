using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage
{
    public int amount;
    public BattleUnit source;
    public bool crit = false;
    public int bonusAmount = 0;

    public Damage(float _amount, BattleUnit _source, int bonusCDMG = 0, int bonusCR = 0, int bonusDMG = 0)
    {
        amount = Mathf.CeilToInt(_amount);
        source = _source;
        if (Random.Range(0, 101) < source.CR.current + bonusCR)
        {
            crit = true;
            bonusAmount += Mathf.CeilToInt(_amount * (source.CDMG.current + bonusCDMG) / 100f);
            bonusAmount += bonusDMG;
        }
    }
}
