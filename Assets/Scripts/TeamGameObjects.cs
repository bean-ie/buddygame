using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamGameObjects : MonoBehaviour
{
    [SerializeField]
    GameObject teammatePrefab;
    GameObject[] teamGameObjects;
    Rigidbody2D[] teamRigidbodies;
    [SerializeField]
    Transform player;
    PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
        teamGameObjects = new GameObject[4];
        teamRigidbodies = new Rigidbody2D[4];
    }

    public void SpawnTeam(CharacterSO[] team)
    {
        for (int i = 0; i < team.Length; i++)
        {
            if (team[i] == null) continue;

            GameObject characterGameObject = Instantiate(teammatePrefab, transform);
            characterGameObject.transform.position = player.position;
            if (characterGameObject.TryGetComponent<SpriteRenderer>(out SpriteRenderer characterSpriteRenderer))
            {
                characterSpriteRenderer.sprite = team[i].unitWorldSprite;
            }
            if (characterGameObject.TryGetComponent<Rigidbody2D>(out Rigidbody2D characterRigidbody))
            {
                teamRigidbodies[i] = characterRigidbody;
            }
        }
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < teamRigidbodies.Length; i++)
        {
            if (teamRigidbodies[i] == null) continue;

            Vector2 fromTo;

            if (i == 0)
            {
                fromTo = player.position;
                fromTo -= teamRigidbodies[i].position;
                if (playerMovement.IsMoving())
                    teamRigidbodies[i].MovePosition(teamRigidbodies[i].position + fromTo.normalized * playerMovement.movementSpeed * Time.fixedDeltaTime);
            }
            else
            {
                fromTo = teamRigidbodies[i - 1].position - teamRigidbodies[i].position;
                if (fromTo.sqrMagnitude >= 1.5)
                {
                    teamRigidbodies[i].MovePosition(teamRigidbodies[i].position + fromTo.normalized * playerMovement.movementSpeed * Time.fixedDeltaTime);
                }
            }
        }
    }
}
