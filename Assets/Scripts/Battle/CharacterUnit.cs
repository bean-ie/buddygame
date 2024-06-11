using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CharacterUnit : BattleUnit
{
    public CharacterSO baseCharacter;
    public CharacterUnit(CharacterSO baseSO)
    {
        isEnemy = false;
        baseCharacter = baseSO;
        SetupStats();
    }
}
