using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private LayerMask platformsLayerMask;
        private CapsuleCollider2D capsuleCollider2D;
        public Animator animator;

        private readonly float pSpeedConstant = 7.5f;
        private readonly float pJumpSpeedConstant = 20f;
        private float previousMoveX;

        public static Vector2 pMovementVector2;
        private Vector2 pSpeed;
        private Rigidbody2D pRigidbody2;

        private float jumpingCooldown;

        public static bool isGrounded = true;

        private void Start()
        {
            pRigidbody2 = GetComponent<Rigidbody2D>();
            capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        }

        public void Update() // anything receives input should be inside update instead of fixedUpdate
        {
            pMovementVector2.x = Input.GetAxisRaw("Horizontal");

            if (IsGrounded() && jumpingCooldown < 0.25f)
                jumpingCooldown += Time.deltaTime;
            if (jumpingCooldown >= 0.25f)
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
            if (IsGrounded())
            {
                if (animator.GetBool("isJumping"))
                {
                    pMovementVector2.y = 0f;
                    jumpingCooldown = 0f; // convert it reversely (initial time be 0.25f)
                }

                isGrounded = true;
                animator.SetBool("isJumping", false);
                animator.SetBool("isGrounded", true);
            }
            else
            {

                isGrounded = false;
                animator.SetBool("isJumping", true);
                animator.SetBool("isGrounded", false);
            }

            // move the rigidBody2D instead of moving the transform to prevent camera shaking 
            //..during wall contact
            if (pMovementVector2.y > 0.1f && IsGrounded())
            {
                pRigidbody2.velocity = new Vector2(pSpeed.x, pJumpSpeedConstant);
                animator.SetTrigger("takeOff");
            }
            else
                pRigidbody2.velocity = new Vector2(pMovementVector2.x * pSpeedConstant, pSpeed.y);

            AnimateRunning(); // can be on fixedUpdate
        }

        private void FaceTowards()
        {
            if ((int)previousMoveX == (int)pMovementVector2.x) return;

            if (pMovementVector2.x != 0)
                transform.localScale = new Vector3(5 * pMovementVector2.x, 5, 1);

            previousMoveX = pMovementVector2.x;
        }

        private void AnimateRunning()
        {
            animator.SetFloat("SpeedX", Mathf.Abs(pMovementVector2.x));
            animator.SetFloat("SpeedY", pSpeed.y);
        }

        private bool IsGrounded()
        {
            // understand this later
            var bCBounds = capsuleCollider2D.bounds;
            RaycastHit2D raycastHit2D = Physics2D.BoxCast(bCBounds.center, bCBounds.size,
                0f, Vector2.down, 0.1f, platformsLayerMask);
            return raycastHit2D.collider != null;
        }
    }

}