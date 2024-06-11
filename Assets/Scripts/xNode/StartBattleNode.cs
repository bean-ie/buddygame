using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBattleNode : BaseNode
{
    public EncounterSO encounter;
    public override void Execute()
    {
        GameManager.instance.dialogueManager.HideDialogueBox();
        GameManager.instance.battleManager.StartBattle(encounter);
    }
}
