using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MemberAbilitySelection : MonoBehaviour
{
    [SerializeField] Image abilityIcon;
    [SerializeField] TMP_Text abilityName;

    public void UpdateMember(Ability ability)
    {
        abilityIcon.sprite = ability.abilityIcon;
        abilityName.text = ability.abilityName;
    }
}
