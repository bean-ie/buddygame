using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectNode : BaseNode
{
    public string targetID;
    public override void Execute()
    {
        foreach (DialogueAccessID id in GameObject.FindObjectsOfType<DialogueAccessID>())
        {
            if (id.id == targetID)
            {
                Destroy(id.gameObject);
            }
        }
        this.NextNode("exit");
    }
}
