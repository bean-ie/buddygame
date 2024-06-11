using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class UpdateDialogueNode : BaseNode {

    public Sprite speakerImage;
    public string speakerName;
    public Color speakerNameColor = new Color(1, 1, 1, 1);
    [TextArea(3, 10)]
    public string text;
    public bool showOptions = false;
    public List<DialogueOption> dialogueOptionsList = new List<DialogueOption>();

    public override void Execute()
    {
        GameManager.instance.dialogueManager.RemoveOptionButtons();
        GameManager.instance.dialogueManager.SetDialogue(speakerImage, speakerName, speakerNameColor, text);
        foreach(DialogueOption option in dialogueOptionsList)
        {
            GameManager.instance.dialogueManager.AddOptionButton(option.dialogue, option.portName);
        }
    }

    [System.Serializable]
    public class DialogueOption
    {
        public string dialogue;
        public string portName;

        public DialogueOption(string _dialogue, string _portName)
        {
            dialogue = _dialogue;
            portName = _portName;
        }
    }
}