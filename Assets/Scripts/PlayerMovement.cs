using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float playerSpeed = 7.5f;
    private float previousMove;

    private Vector2 playerMovementVector2;
    private Rigidbody2D rb2Player;

    public Animator animator;  

    private void Start()
    {
        rb2Player = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // they get values of 0 and 1 in case the button is pressed or not
        playerMovementVector2.x = Input.GetAxisRaw("Horizontal");
        // playerMovementVector2.y = Input.GetAxisRaw("Vertical");
        
        FaceTowards();
        MoveCharacter(playerMovementVector2, playerSpeed);
    }
    
    private void MoveCharacter(Vector2 playerMovementVector2, float playerSpeed)
    {
        // move the rigidBody2D instead of moving the transform to prevent camera shaking 
        //..during wall contact
        playerMovementVector2.Normalize();
        rb2Player.velocity = playerMovementVector2 * playerSpeed;

        AnimateRunning(rb2Player.velocity.x);
    }

    private void FaceTowards()
    {
        if (previousMove == playerMovementVector2.x) return;
        
        if (playerMovementVector2.x != 0)
            transform.localScale = new Vector3(5*playerMovementVector2.x, 5, 1);
 
        previousMove = playerMovementVector2.x;
    }
    
    private void AnimateRunning(float playerVelocity)
    {
        animator.SetFloat("Speed", Mathf.Abs(playerVelocity));
    }
}
