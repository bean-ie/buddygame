using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatusEffectUI : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] TMP_Text counter;

    public void UpdateStatusEffectUI(AppliedStatus status)
    {
        icon.sprite = Helper.GetStatus(status.statusID).statusIcon;
        if (status.stacks == 1) counter.text = "";
        else counter.text = status.stacks.ToString();
    }
}
