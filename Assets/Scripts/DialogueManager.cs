using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public bool dialogueOpen = false;
    public PlayerMovement player;
    [SerializeField] GameObject dialogueBox;
    [SerializeField] Image dialogueImage;
    [SerializeField] TMP_Text dialogueName, dialogueText;

    [SerializeField] Transform buttonHolder;
    [SerializeField] GameObject optionButtonPrefab;
    List<GameObject> optionButtonsList = new List<GameObject>();

    DialogueGraph currentGraph;

    public void ShowDialogueBox(DialogueGraph graph)
    {
        currentGraph = graph;
        dialogueBox.SetActive(true);
        player.canMove = false;
        dialogueOpen = true;
    }

    public void HideDialogueBox()
    {
        RemoveOptionButtons();
        dialogueBox.SetActive(false);
        player.canMove = true;
        dialogueOpen = false;
    }

    private void Update()
    {
        if (dialogueOpen)
        {
            if (currentGraph.currentNode.DynamicOutputs.Count() == 0)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0))
                {
                    currentGraph.currentNode.NextNode("exit");
                }
            }
        }
    }

    public void SetDialogue(Sprite image, string name, Color nameColor, string text)
    {
        dialogueImage.sprite = image;
        dialogueName.text = name;
        dialogueName.color = nameColor;
        dialogueText.text = text;
    }

    public void AddOptionButton(string dialogue, string portName)
    {
        GameObject button = Instantiate(optionButtonPrefab, buttonHolder);
        button.GetComponentInChildren<TMP_Text>().text = dialogue;
        if (button.TryGetComponent<Button>(out Button buttonClass))
        {
            buttonClass.onClick.AddListener(() => OptionButtonClick(portName));
        }
        optionButtonsList.Add(button);
    }

    public void RemoveOptionButtons()
    {
        foreach (GameObject go in optionButtonsList)
        {
            Destroy(go);
        }
        optionButtonsList.Clear();
    }

    public void OptionButtonClick(string portName)
    {
        currentGraph.currentNode.NextNode(portName);
    }
}
