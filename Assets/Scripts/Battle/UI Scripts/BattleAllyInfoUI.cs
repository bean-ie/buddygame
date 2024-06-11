using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleAllyInfoUI : MonoBehaviour
{
    [SerializeField] TMP_Text allyName, allyHealth, allyMP, allyTP;
    [SerializeField] GameObject statuses, statusEffectUIPrefab;
    CharacterUnit character;

    public void SetCharacter(CharacterUnit _character)
    {
        character = _character;
    }

    public void UpdateAllyInfo()
    {
        UpdateAllyInfoName(character.baseCharacter.unitName);
        UpdateAllyInfoHealth(character.HP.current, character.HP.max);
        UpdateAllyInfoMP(character.MP.current, character.MP.max);
        UpdateAllyInfoTP(character.TP.current, character.TP.max);
        UpdateAllyInfoStatuses(character.appliedStatuses);
    }

    void UpdateAllyInfoName(string _name)
    {
        if (allyName != null)
            allyName.text = _name;
    }

    void UpdateAllyInfoHealth(int currentHealth, int maxHealth)
    {
        allyHealth.text = currentHealth.ToString() + "/" + maxHealth.ToString();
    }

    void UpdateAllyInfoMP(int currentMP, int maxMP)
    {
        allyMP.text = currentMP.ToString() + "/" + maxMP.ToString();
    }

    void UpdateAllyInfoTP(int currentTP, int maxTP)
    {
        allyTP.text = currentTP.ToString() + "/" + maxTP.ToString();
    }

    void UpdateAllyInfoStatuses(List<AppliedStatus> statusEffects)
    {
        foreach (Transform child in statuses.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (AppliedStatus status in statusEffects)
        {
            if (status.stacks <= 0) continue;
            GameObject statusEffectUI = Instantiate(statusEffectUIPrefab, statuses.transform);
            StatusEffectUI uiClass = statusEffectUI.GetComponent<StatusEffectUI>();
            uiClass.UpdateStatusEffectUI(status);
        }
    }
}
