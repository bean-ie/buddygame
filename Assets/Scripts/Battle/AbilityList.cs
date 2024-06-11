using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityList : MonoBehaviour
{
    public Ability[] abilityList;

    private void Start()
    {
        abilityList[0] = new PlaceholderAbility();
    }

}
