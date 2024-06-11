using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using XNode;
using XNodeEditor;
using System.Linq;

[CustomNodeEditor(typeof(UpdateDialogueNode))]
public class DialogueNodeDrawer : NodeEditor
{
    private UpdateDialogueNode dialogueNode;

    private bool showNodeSettings = false;
    private bool showDialogueSettings = true;
    private string newDialogueOption = "";
    private string newDialogueOptionPort = "";
    private int currentNodeTab = 0;
    private int nodePortToDelete = 0;
    public override void OnBodyGUI()
    {
        if (dialogueNode == null)
        {
            dialogueNode = target as UpdateDialogueNode;
        }

        NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("entry"));
        NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("exit"));

        showNodeSettings = EditorGUILayout.BeginFoldoutHeaderGroup(showNodeSettings, "Node Settings");

        if (showNodeSettings)
        {
            currentNodeTab = GUILayout.Toolbar(currentNodeTab, new string[] {"Add Port", "Remove Port"});

            switch (currentNodeTab)
            {
                case 0:
                    EditorGUILayout.PrefixLabel("Dialogue");
                    newDialogueOption = EditorGUILayout.TextField(newDialogueOption);
                    EditorGUILayout.PrefixLabel("Port");
                    newDialogueOptionPort = EditorGUILayout.TextField(newDialogueOptionPort);
                    if (GUILayout.Button("Create new option"))
                    {
                        if (newDialogueOption.Length == 0 || newDialogueOptionPort.Length == 0)
                        {
                            EditorUtility.DisplayDialog("Error creating port", "The fields aren't filled", "OK");
                        }
                        else
                        {
                            bool matchExistingPort = false;
                            foreach (NodePort port in dialogueNode.DynamicOutputs)
                            {
                                if (port.fieldName == newDialogueOptionPort)
                                {
                                    matchExistingPort = true;
                                }
                            }
                            if (matchExistingPort)
                            {
                                EditorUtility.DisplayDialog("Error creating port", "That port already exists", "OK");
                            }
                            else
                            {
                                dialogueNode.AddDynamicOutput(typeof(int), Node.ConnectionType.Multiple, Node.TypeConstraint.None, newDialogueOptionPort);
                                dialogueNode.dialogueOptionsList.Add(new UpdateDialogueNode.DialogueOption(newDialogueOption, newDialogueOptionPort));
                            }
                        }
                    }
                    break;
                case 1:
                    if (dialogueNode.DynamicOutputs.Count() == 0)
                    {
                        EditorGUILayout.HelpBox("There are no dynamic ports on this node", MessageType.Warning);
                    }
                    else
                    {
                        EditorGUILayout.PrefixLabel("Choose port");

                        List<string> outputs = new List<string>();
                        foreach (NodePort port in dialogueNode.DynamicOutputs)
                        {
                            outputs.Add(port.fieldName);
                        }

                        nodePortToDelete = EditorGUILayout.Popup(nodePortToDelete, outputs.ToArray());

                        if (GUILayout.Button("Delete node"))
                        {
                            foreach (UpdateDialogueNode.DialogueOption d in dialogueNode.dialogueOptionsList)
                            {
                                if (d.portName == dialogueNode.DynamicOutputs.ElementAt(nodePortToDelete).fieldName)
                                {
                                    dialogueNode.dialogueOptionsList.Remove(d);
                                    break;
                                }
                            }

                            dialogueNode.RemoveDynamicPort(dialogueNode.DynamicOutputs.ElementAt(nodePortToDelete));
                        }
                    }
                    break;
            }
        }

        EditorGUILayout.EndFoldoutHeaderGroup();

        showDialogueSettings = EditorGUILayout.BeginFoldoutHeaderGroup(showDialogueSettings, "Dialogue Settings");
        
        if (showDialogueSettings)
        {
            dialogueNode.speakerImage = (Sprite)EditorGUILayout.ObjectField("Speaker Sprite", dialogueNode.speakerImage, typeof(Sprite), false);
            dialogueNode.speakerName = EditorGUILayout.TextField("Speaker Name", dialogueNode.speakerName);
            dialogueNode.speakerNameColor = EditorGUILayout.ColorField("Name Color", dialogueNode.speakerNameColor);
            NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("text"));

            foreach (UpdateDialogueNode.DialogueOption d in dialogueNode.dialogueOptionsList)
            {
                EditorGUILayout.PrefixLabel(d.dialogue);
                d.dialogue = EditorGUILayout.TextField(d.dialogue);
                EditorGUILayout.TextField(d.portName);
                EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
            }

            foreach (NodePort port in dialogueNode.DynamicOutputs)
            {
                NodeEditorGUILayout.PortField(port);
            }
        }

        EditorGUILayout.EndFoldoutHeaderGroup();

        serializedObject.ApplyModifiedProperties();
        serializedObject.Update();
    }
}
