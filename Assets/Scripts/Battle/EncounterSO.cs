using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Encounter", menuName = "Scriptable Objects/Encounter", order = 2)]
public class EncounterSO : ScriptableObject
{
    public EnemySO[] enemies;
}
