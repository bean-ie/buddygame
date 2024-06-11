using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage
{
    public int amount;
    public BattleUnit source;
    public bool crit = false;
    public int bonusAmount = 0;

    public Damage(int _amount, BattleUnit _source)
    {
        amount = _amount;
        source = _source;
        if (Random.Range(0, 101) < source.CR.current)
        {
            crit = true;
            bonusAmount += _amount * source.CDMG.current / 100;
        }
    }

    public Damage(float _amount, BattleUnit _source)
    {
        amount = Mathf.CeilToInt(_amount);
        source = _source;
        if (Random.Range(0, 101) < source.CR.current)
        {
            crit = true;
            bonusAmount += Mathf.CeilToInt(_amount * source.CDMG.current / 100f);
        }
    }
}
