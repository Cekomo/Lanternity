using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float playerSpeed = 7.5f;
    private float jumpSpeed = 100f;
    private float previousMove;

    private Vector2 playerMovementVector2;
    private Rigidbody2D rb2Player;

    public Animator animator;  

    private void Start()
    {
        rb2Player = GetComponent<Rigidbody2D>();
    }

    // private void Update()
    // {
    //     
    // }
    
    private void FixedUpdate()
    {
        // they get values of 0 and 1 in case the button is pressed or not
        
        playerMovementVector2.x = Input.GetAxisRaw("Horizontal");
        MoveCharacter();

        FaceTowards();
        AnimateRunning(rb2Player.velocity.x);
    }
    
    private void MoveCharacter()
    {
        // move the rigidBody2D instead of moving the transform to prevent camera shaking 
        //..during wall contact

        if (Input.GetKey(KeyCode.D))
            rb2Player.velocity = new Vector2(5f, rb2Player.velocity.y);
        else if (Input.GetKey(KeyCode.A))
            rb2Player.velocity = new Vector2(-5f,  rb2Player.velocity.y);
        if (Input.GetKey(KeyCode.W))
            rb2Player.velocity = new Vector2(rb2Player.velocity.x, 10f);
        
        // if (Input.GetKeyDown(KeyCode.W))
        // {
        //     rb2Player.velocity = new Vector2(playerMovementVector2.x * playerSpeed, jumpSpeed);
        // }
        // else
        // {
        //     rb2Player.velocity = new Vector2(playerMovementVector2.x * playerSpeed, 0);
        // }
        
        AnimateRunning(rb2Player.velocity.x);
    }

    private void FaceTowards()
    {
        if ((int)previousMove == (int)playerMovementVector2.x) return;
        
        if (playerMovementVector2.x != 0)
            transform.localScale = new Vector3(5*playerMovementVector2.x, 5, 1);
    
        previousMove = playerMovementVector2.x;
    }
    
    private void AnimateRunning(float playerVelocity)
    {
        animator.SetFloat("Speed", Mathf.Abs(playerVelocity));
    }
}
