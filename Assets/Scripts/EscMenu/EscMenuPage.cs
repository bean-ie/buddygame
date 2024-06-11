using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EscMenuPage : MonoBehaviour
{
    public virtual void OpenPage()
    {
        gameObject.SetActive(true);
    }
    
    public virtual void ClosePage()
    {
        gameObject.SetActive(false);
    }

    public abstract void UpdatePage();
    public virtual void ErasePage() { }
}
