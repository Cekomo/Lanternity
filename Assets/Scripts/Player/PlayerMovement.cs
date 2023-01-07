using Lantern;
using Light;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private LayerMask platformsLayerMask;
        private CapsuleCollider2D capsuleCollider2D;
        public Animator animator;

        private static readonly int IsJumping = Animator.StringToHash("isJumping");
        private static readonly int IsGrounded = Animator.StringToHash("isGrounded");
        private static readonly int TakeOff = Animator.StringToHash("takeOff");
        private static readonly int SpeedY = Animator.StringToHash("SpeedY");
        
        private const float pJumpSpeedConstant = 20f;
        private float previousMoveX;

        private static Vector2 pMovementVector2;
        private Vector2 pSpeed;
        private Rigidbody2D pRigidbody2;

        private float jumpingCooldown;

        private void Start()
        {
            pRigidbody2 = GetComponent<Rigidbody2D>();
            capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        }

        public void Update() // anything receives input should be inside update instead of fixedUpdate
        {
            if (CheckIfGrounded() && jumpingCooldown < 0.25f)
                jumpingCooldown += Time.deltaTime;
            if (jumpingCooldown >= 0.25f)
                pMovementVector2.y = Input.GetAxisRaw("Vertical");

            if (pMovementVector2.x == 0 && pMovementVector2.y == 0) return; // check here !
            animator.SetBool(PlayerMouseHandler.IsLanternUsed, false);
            LightIntensityController.LanternState = LanternFlickState.Idle;
        }

        private void FixedUpdate()
        {
            pSpeed = pRigidbody2.velocity;

            MoveCharacter();
        }

        private void MoveCharacter()
        {
            if (CheckIfGrounded())
            {
                if (animator.GetBool(IsJumping))
                {
                    pMovementVector2.y = 0f;
                    jumpingCooldown = 0f; // convert it reversely (initial time be 0.25f)
                }
                
                animator.SetBool(IsJumping, false);
                animator.SetBool(IsGrounded, true);
            }
            else
            {
                animator.SetBool(IsJumping, true);
                animator.SetBool(IsGrounded, false);
            }

            // move the rigidBody2D instead of moving the transform to prevent camera shaking 
            //..during wall contact
            if (pMovementVector2.y > 0.1f && CheckIfGrounded())
            {
                pRigidbody2.velocity = new Vector2(pSpeed.x, pJumpSpeedConstant);
                animator.SetTrigger(TakeOff);
            }

            AnimateRunning(); // can be on fixedUpdate
        }

        private void AnimateRunning()
        {
            animator.SetFloat(SpeedY, pSpeed.y);
        }

        private bool CheckIfGrounded()
        {
            // understand this later
            var bCBounds = capsuleCollider2D.bounds;
            RaycastHit2D raycastHit2D = Physics2D.BoxCast(bCBounds.center, bCBounds.size,
                0f, Vector2.down, 0.1f, platformsLayerMask);
            return !ReferenceEquals(raycastHit2D.collider, null); // changed from raycastHit2D.collider != null;
        }
    }

}