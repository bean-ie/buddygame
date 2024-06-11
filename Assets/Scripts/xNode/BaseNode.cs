using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class BaseNode : Node {

    [Input] public int entry;
    [Output] public int exit;

    protected override void Init()
    {
        base.Init();
    }

    public virtual void Execute()
    {
        NextNode("exit");
    }

    public void NextNode(string _exit)
    {
        BaseNode b = null;
        foreach (NodePort port in Ports)
        {
            if (port.fieldName == _exit)
            {
                b = port.Connection.node as BaseNode;
                break;
            }
        }
        if (b != null)
        {
            DialogueGraph _graph = graph as DialogueGraph;
            _graph.currentNode = b;
            _graph.Execute();
        }
    }
}