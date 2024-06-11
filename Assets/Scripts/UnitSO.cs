using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSO : ScriptableObject
{
    public bool isEnemy;
    public Sprite unitWorldSprite;
    public string unitName;

    public int baseHP, baseMP, baseTP, baseATK, baseMATK, baseCR = 5, baseCDMG = 50, baseDEF, baseMDEF;

    public int[] activeAbilityIDs;
    public int[] passiveAbilityIDs;

    public PassiveEffect GetPassiveEffectAt(int abilityIndex, int effectIndex)
    {
        return GameManager.instance.idManager.effects[GameManager.instance.idManager.passives[passiveAbilityIDs[abilityIndex]].effectIDs[effectIndex]];
    }
}
