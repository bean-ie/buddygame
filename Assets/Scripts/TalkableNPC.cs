using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkableNPC : MonoBehaviour, IInteractable
{
    public float talkDistance;
    public GameObject talkIndicator;
    [SerializeField] DialogueGraph dialogue;

    public void ActivateIndicator()
    {
        if (talkIndicator == null) return;
        talkIndicator.SetActive(true);
    }

    public void DeactivateIndicator()
    {
        if (talkIndicator == null) return;
        talkIndicator.SetActive(false);
    }

    public void Interact()
    {
        if (GameManager.instance.dialogueManager.dialogueOpen) return;
        dialogue.Start();
    }
}
