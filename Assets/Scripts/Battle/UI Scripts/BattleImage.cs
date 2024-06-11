using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class BattleImage : MonoBehaviour
{
    public Image image;
    Color originalColor;
    Color flashTargetColor;
    float flashStartupTime;
    float flashDuration;
    float flashEndTime;
    Vector3 currentTargetPosition;
    public Vector3 originalPosition;
    bool flashing = false;

    public void FlashColor(Color flashColor, float startupTime, float duration, float endTime)
    {
        if (flashing) return;
        originalColor = image.color;
        flashTargetColor = flashColor;
        flashStartupTime = startupTime;
        flashDuration = duration;
        flashEndTime = endTime;
        StartCoroutine(FlashCoroutine());
    }

    IEnumerator FlashCoroutine()
    {
        flashing = true;
        float startupTimer = 0;

        while (startupTimer < flashStartupTime)
        {
            image.color = Color.Lerp(originalColor, flashTargetColor, startupTimer);
            startupTimer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        startupTimer = 0;
        image.color = flashTargetColor;

        yield return new WaitForSeconds(flashDuration);

        while (startupTimer < flashEndTime)
        {
            image.color = Color.Lerp(flashTargetColor, originalColor, startupTimer);
            startupTimer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        image.color = originalColor;
        flashing = false;
    }

    public void MoveToObject(Vector3 targetObject)
    {
        currentTargetPosition = targetObject;
        StartCoroutine("MoveToTargetCoroutine");
    }

    public void MoveToOriginalPosition()
    {
        MoveToObject(originalPosition);
    }

    IEnumerator MoveToTargetCoroutine()
    {
        float progress = 0;
        Vector3 originalPos = transform.position;
        while (progress < 1)
        {
            transform.position = Vector3.Lerp(originalPos, currentTargetPosition, Helper.BezierBlend(progress));
            progress += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = currentTargetPosition;
    }
}
