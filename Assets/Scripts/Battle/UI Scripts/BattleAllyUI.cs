using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAllyUI : BattleUnitUI
{
    public BattleAllyInfoUI battleInfoUI;

    public void SetupAllyInfo(Transform parent, GameObject prefab, CharacterUnit character)
    {
        GameObject battleInfoUIGameObject = GameObject.Instantiate(prefab, parent);
        if (battleInfoUIGameObject.TryGetComponent<BattleAllyInfoUI>(out BattleAllyInfoUI info))
        {
            info.SetCharacter(character);
            info.UpdateAllyInfo();
            battleInfoUI = info;
        }
    }

    public void ResetAllyInfo()
    {
        GameObject.Destroy(battleInfoUI.gameObject);
    }

    public void UpdateAllyInfo()
    {
        battleInfoUI.UpdateAllyInfo();
    }
}
