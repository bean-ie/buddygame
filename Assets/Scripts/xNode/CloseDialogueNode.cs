using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class CloseDialogueNode : BaseNode {
    public bool goOn;
    public override void Execute()
    {
        GameManager.instance.dialogueManager.HideDialogueBox();
        if (goOn)
        {
            this.NextNode("exit");
        }
    }
}