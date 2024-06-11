using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetSelectionUI : MonoBehaviour
{
    [SerializeField] Transform alliesGrid, enemiesGrid;
    [SerializeField] GameObject buttonPrefab;
    [SerializeField] Transform battleCanvas;
    List<GameObject> currentButtons = new List<GameObject>();

    public void CreateTargetSelectionButtons(bool targetAlly = false)
    {
        if (!targetAlly)
        {
            for (int i = 0; i < GameManager.instance.battleManager.currentBattle.EnemyCount(); i++)
            {
                CreateButton(enemiesGrid.GetChild(i), i + GameManager.instance.teamManager.teamUnits.Length);
            }
        }
        else
        {
            for (int i = 0; i < GameManager.instance.teamManager.teamUnits.Length; i++)
            {
                CreateButton(alliesGrid.GetChild(i), i);
            }
        }
    }

    void CreateButton(Transform targetTransform, int id)
    {
        GameObject button = Instantiate(buttonPrefab, battleCanvas);
        button.transform.position = targetTransform.position;
        currentButtons.Add(button);
        if (button.TryGetComponent<Button>(out Button targetButton))
        {
            targetButton.onClick.AddListener(() => GameManager.instance.battleManager.SelectTarget(id));
            if (GameManager.instance.battleManager.currentBattle.GetUnitAt(id).isDead) targetButton.interactable = false;
        } 
    }

    public void DestroyAllButtons()
    {
        foreach (GameObject go in currentButtons)
        {
            Destroy(go);
        }
    }
}