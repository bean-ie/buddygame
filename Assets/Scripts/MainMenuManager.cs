using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject menuObject;
    [SerializeField] float speed;
    Vector3 targetPage;
    Vector3 startPosition;
    bool moving;
    float moveProgress;

    public void SwitchScenes(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SwitchPage(Transform newPage)
    {
        startPosition = menuObject.transform.localPosition;
        targetPage = newPage.localPosition;
        moveProgress = 0;
        moving = true;
    }

    public void OpenURL(string url)
    {
        Application.OpenURL(url);
    }

    private void Update()
    {
        if (moving)
        {
            menuObject.transform.localPosition = Vector3.Lerp(startPosition, -targetPage, Helper.BezierBlend(moveProgress));
            moveProgress += Time.deltaTime;
            if (moveProgress >= 1)
            {
                moving = false;
                menuObject.transform.localPosition = -targetPage;
            }
        }
    }
}
