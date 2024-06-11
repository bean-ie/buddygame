using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public bool canMove = true;
    Rigidbody2D rb;
    Vector2 inputVector;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        GameManager.instance.dialogueManager.player = this;
        GameManager.instance.battleManager.player = this;
    }

    void Update()
    {
        // input gathering
        inputVector.x = Input.GetAxisRaw("Horizontal");
        inputVector.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        // moving the rigibody
        if (canMove) rb.MovePosition(rb.position + inputVector.normalized * movementSpeed * Time.fixedDeltaTime);
    }

    public bool IsMoving()
    {
        return ((inputVector.x != 0 || inputVector.y != 0) && canMove);
    }
}
