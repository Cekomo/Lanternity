using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask platformsLayerMask;
    private BoxCollider2D boxCollider2D;
    
    private readonly float playerSpeed = 7.5f;
    private readonly float jumpSpeed = 20f;
    private bool isJumping = true;
    private float previousMove;

    private Vector2 playerMovementVector2;
    private Rigidbody2D rb2Player;

    public Animator animator;  

    private void Start()
    {
        rb2Player = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update() // anything receives input should be inside update instead of fixedUpdate
    {
        playerMovementVector2.x = Input.GetAxisRaw("Horizontal");
        playerMovementVector2.y = Input.GetAxisRaw("Vertical");
    }
    
    private void FixedUpdate()
    {
        // they get values of 0 and 1 in case the button is pressed or not
        
        MoveCharacter();
        FaceTowards();
    }
    
    private void MoveCharacter()
    {
        // move the rigidBody2D instead of moving the transform to prevent camera shaking 
        //..during wall contact

        if (playerMovementVector2.y > 0.1f)
        {
            if (IsGrounded() && isJumping)
            {
                rb2Player.velocity = new Vector2(rb2Player.velocity.x, jumpSpeed);
                animator.SetTrigger("takeOff");
                isJumping = false;
            }
        }
        else
            rb2Player.velocity = new Vector2(playerMovementVector2.x * playerSpeed, rb2Player.velocity.y);

        if (playerMovementVector2.y < 0.2f)
            animator.SetBool("isJumping", false);
        else
        {
            animator.SetBool("isJumping", true);
            isJumping = true;
        }


        AnimateRunning(); // can be on fixedUpdate
    }

    private void FaceTowards()
    {
        if ((int)previousMove == (int)playerMovementVector2.x) return;
        
        if (playerMovementVector2.x != 0)
            transform.localScale = new Vector3(5*playerMovementVector2.x, 5, 1);
    
        previousMove = playerMovementVector2.x;
    }
    
    private void AnimateRunning()
    {
        animator.SetFloat("Speed", Mathf.Abs(playerMovementVector2.x));
    }

    private bool IsGrounded()
    { // understand this later
        var bCBounds = boxCollider2D.bounds;
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(bCBounds.center, bCBounds.size, 
            0f, Vector2.down, 0.1f, platformsLayerMask);
        return raycastHit2D.collider != null;
    }
}
