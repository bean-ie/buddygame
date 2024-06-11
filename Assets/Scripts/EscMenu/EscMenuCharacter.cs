using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EscMenuCharacter : MonoBehaviour
{
    [SerializeField] Image characterFace;
    [SerializeField] TMP_Text characterName, characterHealth;

    public void UpdateCharacter(CharacterUnit character)
    {
        characterFace.sprite = character.baseCharacter.characterFace;
        characterName.text = character.baseCharacter.unitName;
        characterHealth.text = character.HP.current.ToString() + "/" + character.HP.max.ToString();
    }
}
