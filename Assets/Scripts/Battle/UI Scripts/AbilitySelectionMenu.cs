using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitySelectionMenu : MonoBehaviour
{
    [SerializeField] GameObject selectionMenuGameObject;
    [SerializeField] Transform gridTransform;
    [SerializeField] GameObject abilityPrefab;

    List<GameObject> members = new List<GameObject>();

    public void OpenSelectionMenu()
    {
        selectionMenuGameObject.SetActive(true);
    }

    public void UpdateSelectionMenu(BattleUnit unit)
    {
        foreach (int abilityNum in unit.GetBaseCharacter().activeAbilityIDs)
        {
            Ability ability = GameManager.instance.idManager.abilities[abilityNum];
            ability.UpdateAbilityInfo();
            GameObject memberGO = Instantiate(abilityPrefab, gridTransform);
            if (memberGO.TryGetComponent<MemberAbilitySelection>(out MemberAbilitySelection member))
            {
                member.UpdateMember(ability);
                members.Add(memberGO);
            } else { Debug.LogError("Ability Member has no MemberAbilitySelection."); }
            if (memberGO.TryGetComponent<Button>(out Button button))
            {
                button.onClick.AddListener(() => GameManager.instance.battleManager.ChoosePlayerAbility(ability));
                if (unit.MP.current < ability.MPcost || unit.TP.current < ability.TPcost || !ability.IsAvailable(unit))
                {
                    button.interactable = false;
                }
            } else { Debug.LogError("Ability Member has no Button."); }
        }
    }

    public void CloseSelectionMenu()
    {
        foreach (GameObject memberGO in members)
        {
            Destroy(memberGO);
        }
        selectionMenuGameObject.SetActive(false);
    }
}
