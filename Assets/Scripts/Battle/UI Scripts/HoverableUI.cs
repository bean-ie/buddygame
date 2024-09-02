using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverableUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Ability ability;
    GameObject message;
    GameObject prefab;
    bool isBeingHovered;

    public void SetupHoverable(Ability _ability, GameObject _prefab)
    {
        ability = _ability;
        prefab = _prefab;
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (message) Destroy(message);
        message = Instantiate(prefab, GetComponentInParent<Canvas>().transform);
        message.GetComponent<HoverMessageUI>().SetupMessage(ability);
        isBeingHovered = true;
    }

    private void Update()
    {
        if (isBeingHovered)
        {
            if (message) message.transform.position = Input.mousePosition;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isBeingHovered = false;
        Destroy(message);
    }

    private void OnDestroy()
    {
        Destroy(message);
    }
}
