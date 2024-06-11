using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUnitUI
{
    public BattleImage battleImage;
    public GameObject battleSpriteGameObject;
    Color originalColor;

    public virtual void SetupBattleSprite(Transform parent, Sprite sprite, GameObject prefab)
    {
        battleSpriteGameObject = GameObject.Instantiate(prefab, parent);
        if (battleSpriteGameObject.TryGetComponent<BattleImage>(out BattleImage image))
        {
            image.image.sprite = sprite;
            battleImage = image;
            originalColor = image.image.color;
            image.originalPosition = image.transform.position;
        }
    }

    public virtual void ResetBattleSprite()
    {
        GameObject.Destroy(battleSpriteGameObject);
    }

    public virtual void DarkenBattleSprite()
    {
        Color darkenedColor = originalColor;
        darkenedColor *= 0.5f;
        darkenedColor.a = 1;
        battleImage.image.color = darkenedColor;
    }

    public virtual void UndarkenBattleSprite()
    {
        battleImage.image.color = originalColor;
    }

    public virtual void FlashColor(Color flashColor, float startupTime, float duration, float endTime)
    {
        battleImage.FlashColor(flashColor, startupTime, duration, endTime);
    }

    public virtual void MoveToObject(Vector3 targetObject)
    {
        battleImage.MoveToObject(targetObject);
    }

    public virtual void MoveToOriginalPosition()
    {
        battleImage.MoveToOriginalPosition();
    }
}
