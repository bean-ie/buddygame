using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNPCInteraction : MonoBehaviour
{
    TalkableNPC[] NPCs;
    TalkableNPC selectedNPC;

    void Start()
    {
        NPCs = GameObject.FindObjectsOfType<TalkableNPC>();
    }

    float SqrDistanceToNPC(TalkableNPC npc)
    {
        if (npc == null) return 99999999;
        return Vector2.SqrMagnitude(transform.position - npc.transform.position);
    }

    void Update()
    {
        foreach (TalkableNPC npc in NPCs)
        {
            if (SqrDistanceToNPC(npc) <= npc.talkDistance * npc.talkDistance)
            {
                if (SqrDistanceToNPC(npc) < SqrDistanceToNPC(selectedNPC))
                {
                    if (selectedNPC != null) selectedNPC.DeactivateIndicator();
                    npc.ActivateIndicator();
                    selectedNPC = npc;
                }
            }
        }
        if (selectedNPC != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (GetComponent<PlayerMovement>().canMove)
                {
                    selectedNPC.Interact();
                }
            }
            
            if (SqrDistanceToNPC(selectedNPC) > selectedNPC.talkDistance * selectedNPC.talkDistance)
            {
                selectedNPC.DeactivateIndicator();
                selectedNPC = null;
            }
        }
    }
}
