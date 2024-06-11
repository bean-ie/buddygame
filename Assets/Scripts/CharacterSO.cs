using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Scriptable Objects/Character", order = 0)]
public class CharacterSO : UnitSO
{
    public Sprite characterFace;
    public int attackAbilityID;
}
