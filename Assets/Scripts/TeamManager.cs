using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour
{
    [SerializeField]
    CharacterSO[] teamBaseCharacters;
    public CharacterUnit[] teamUnits;
    
    private void Start()
    {

    }

    public void Begin()
    {
        SetupCharacters();
        FindObjectOfType<TeamGameObjects>().SpawnTeam(teamBaseCharacters);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            SetupCharacters(true);
        }
    }

    private void SetupCharacters(bool reset = false)
    {
        teamUnits = new CharacterUnit[teamBaseCharacters.Length];
        for(int i = 0; i < teamBaseCharacters.Length; i++)
        {
            teamUnits[i] = new CharacterUnit(teamBaseCharacters[i]);
        }
    }
}
