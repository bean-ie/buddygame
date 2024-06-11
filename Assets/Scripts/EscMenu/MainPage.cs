using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPage : EscMenuPage
{
    [SerializeField] GameObject characterPrefab;
    [SerializeField] Transform gridLayoutParent;
    public override void UpdatePage()
    {
        foreach (CharacterUnit character in GameManager.instance.teamManager.teamUnits)
        {
            EscMenuCharacter createdCharacter = Instantiate(characterPrefab, gridLayoutParent).GetComponent<EscMenuCharacter>();
            createdCharacter.UpdateCharacter(character);
        }
    }

    public override void ErasePage()
    {
        foreach (Transform child in gridLayoutParent)
        {
            Destroy(child.gameObject);
        }
    }
}
