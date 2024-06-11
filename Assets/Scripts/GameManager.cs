using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public DialogueManager dialogueManager;
    public TeamManager teamManager;
    public MenuManager menuManager;
    public BattleManager battleManager;
    public IDManager idManager;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } 
        else
        {
            Destroy(gameObject);
            return;
        }
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SetAllChildrenActive(scene.buildIndex != 0);
        if (scene.buildIndex != 0)
        {
            teamManager.Begin();
            menuManager.Begin();
        }
    }

    void SetAllChildrenActive(bool value)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(value);
        }
    }
}
