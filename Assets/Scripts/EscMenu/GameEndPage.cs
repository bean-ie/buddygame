using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndPage : EscMenuPage
{
    public override void UpdatePage()
    {
        SceneManager.LoadScene(0);
    }
}
