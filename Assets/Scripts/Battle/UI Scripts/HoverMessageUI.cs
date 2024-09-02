using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HoverMessageUI : MonoBehaviour
{
    [SerializeField] TMP_Text abilityName, description, mpCost, tpCost, tpGain;
    [SerializeField] Image background;
    Camera sceneCamera;
    Vector3 offsetMultipliers;
    Vector3 offset;
    public void SetupMessage(Ability ability)
    {
        sceneCamera = FindObjectOfType<Camera>();
        abilityName.text = ability.abilityName;
        description.text = ability.abilityDescription;

        if (ability.MPcost == 0) mpCost.gameObject.SetActive(false);
        else mpCost.text = "MP cost: " + ability.MPcost.ToString();

        if (ability.TPcost == 0) tpCost.gameObject.SetActive(false);
        else tpCost.text = "TP cost: " + ability.TPcost.ToString();

        if (ability.TPgain == 0) tpGain.gameObject.SetActive(false);
        else tpGain.text = "TP gain: " + ability.TPgain.ToString();

        if (transform.position.x + background.rectTransform.sizeDelta.x > Screen.width)
        {
            offsetMultipliers.x = -1;
        }
        else offsetMultipliers.x = 1;

        if (transform.position.y + background.rectTransform.sizeDelta.y < 0)
        {
            offsetMultipliers.y = 1;
        }
        else offsetMultipliers.y = -1;

        background.rectTransform.localPosition = new Vector3(background.rectTransform.sizeDelta.x / 2 * offsetMultipliers.x, background.rectTransform.sizeDelta.y / 2 * offsetMultipliers.y, 0);
    }

    private void Update()
    {
        if (transform.position.x + background.rectTransform.sizeDelta.x > Screen.width)
        {
            offsetMultipliers.x = -1;
        }
        else offsetMultipliers.x = 1;

        if (transform.position.y + background.rectTransform.sizeDelta.y < 0)
        {
            offsetMultipliers.y = 1;
        }
        else offsetMultipliers.y = -1;

        background.rectTransform.localPosition = new Vector3(background.rectTransform.sizeDelta.x/2 * offsetMultipliers.x, background.rectTransform.sizeDelta.y/2 * offsetMultipliers.y, 0); 
    }
}
