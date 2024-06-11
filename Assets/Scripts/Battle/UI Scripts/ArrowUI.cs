using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class ArrowUI : MonoBehaviour
{
    public void HideArrow()
    {
        GetComponent<Image>().enabled = false;
    }

    public void ShowArrow()
    {
        GetComponent<Image>().enabled = true;
    }

    public void MoveToUnit(BattleUnitUI unit, bool enemy)
    {
        transform.position = unit.battleImage.transform.position + Vector3.right * 100 * (enemy ? -1 : 1);
        transform.rotation = Quaternion.Euler(0, 0, (enemy ? -90 : 90));
    }
}
