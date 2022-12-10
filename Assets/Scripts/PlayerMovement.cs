using System.Collections;
using System.Linq;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask platformsLayerMask;
    private BoxCollider2D boxCollider2D;
    
    private readonly float pSpeedConstant = 7.5f;
    private readonly float pJumpSpeedConstant = 20f;
    private float previousMoveX;

    private Vector2 pMovementVector2;
    private Vector2 pSpeed;
    private Rigidbody2D pRigidbody2;

    public Animator animator;  

    private void Start()
    {
        pRigidbody2 = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update() // anything receives input should be inside update instead of fixedUpdate
    {
        pMovementVector2.x = Input.GetAxisRaw("Horizontal");
        pMovementVector2.y = Input.GetAxisRaw("Vertical");
    }
    
    private void FixedUpdate()
    {
        pSpeed = pRigidbody2.velocity;
        
        MoveCharacter();
        FaceTowards();
    }
    
    private void MoveCharacter()
    {
        // move the rigidBody2D instead of moving the transform to prevent camera shaking 
        //..during wall contact
        if (pMovementVector2.y > 0.1f)
        {
            if (IsGrounded())
            {
                pRigidbody2.velocity = new Vector2(pSpeed.x, pJumpSpeedConstant);
                animator.SetTrigger("takeOff");
            }
        }
        else
            pRigidbody2.velocity = new Vector2(pMovementVector2.x * pSpeedConstant, pSpeed.y);

        if (IsGrounded())
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isGrounded", true);
        }
        else
        {
            animator.SetBool("isJumping", true);
            animator.SetBool("isGrounded", false);
        }
        
        AnimateRunning(); // can be on fixedUpdate
    }

    private void FaceTowards()
    {
        if ((int)previousMoveX == (int)pMovementVector2.x) return;
        
        if (pMovementVector2.x != 0)
            transform.localScale = new Vector3(5*pMovementVector2.x, 5, 1);
    
        previousMoveX = pMovementVector2.x;
    }
    
    private void AnimateRunning()
    {
        animator.SetFloat("SpeedX", Mathf.Abs(pMovementVector2.x));
        animator.SetFloat("SpeedY", pSpeed.y);
    }

    private bool IsGrounded()
    { // understand this later
        var bCBounds = boxCollider2D.bounds;
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(bCBounds.center, bCBounds.size,
            0f, Vector2.down, 0.1f, platformsLayerMask);
        return raycastHit2D.collider != null;
    }
}
