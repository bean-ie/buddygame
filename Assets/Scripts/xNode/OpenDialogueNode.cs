using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class OpenDialogueNode : BaseNode {
    public override void Execute()
    {
        GameManager.instance.dialogueManager.ShowDialogueBox(graph as DialogueGraph);
        this.NextNode("exit");
    }
}