using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float playerSpeed = 7.5f;

    private Vector2 playerMovementVector2;
    private Rigidbody2D rb2Player;

    void Start()
    {
        rb2Player = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        playerMovementVector2.x = Input.GetAxisRaw("Horizontal");
        playerMovementVector2.y = Input.GetAxisRaw("Vertical");

        MoveCharacter(rb2Player, playerMovementVector2, playerSpeed);
    }
    
    public void MoveCharacter(Rigidbody2D rb2Player, Vector2 playerMovementVector2, float playerSpeed)
    {
        // move the rigidBody2D instead of moving the transform to prevent camera shaking 
        //..during wall contact
        playerMovementVector2.Normalize();
        rb2Player.velocity = playerMovementVector2 * playerSpeed;
    }
}
