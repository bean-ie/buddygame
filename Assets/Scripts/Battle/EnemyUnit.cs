using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : BattleUnit
{
    public EnemySO baseCharacter;

    public EnemyUnit(EnemySO baseSO)
    {
        isEnemy = true;
        baseCharacter = baseSO;
        SetupStats();
    }
}
