using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    GameObject menuGameObject;
    bool menuOpen = false;

    [SerializeField]
    EscMenuPage mainPage;
    EscMenuPage currentPage;

    private void Start()
    {

    }

    public void Begin()
    {
        SwitchToPage(mainPage);
        menuGameObject.SetActive(false);
        menuOpen = false;
    }

    public void SwitchToPage(EscMenuPage page)
    {
        if (currentPage != null)
        {
            currentPage.ErasePage();
            currentPage.ClosePage();
        }
        page.UpdatePage();
        page.OpenPage();
        currentPage = page;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!menuOpen)
            {
                SwitchToPage(mainPage);
                menuGameObject.SetActive(true);
                menuOpen = true;
            }
            else if ((currentPage == mainPage) && menuOpen)
            {
                menuGameObject.SetActive(false);
                menuOpen = false;
            }
            else if ((currentPage != mainPage) && menuOpen)
            {
                SwitchToPage(mainPage);
            }
        }
    }
}
