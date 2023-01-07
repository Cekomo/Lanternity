using Lantern;
using Light;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : PlayerProperties
    {
        private static readonly int IsJumping = Animator.StringToHash("isJumping");
        private static readonly int IsGrounded = Animator.StringToHash("isGrounded");
        private static readonly int TakeOff = Animator.StringToHash("takeOff");
        private static readonly int SpeedY = Animator.StringToHash("SpeedY");
        
        private const float pJumpSpeedConstant = 20f;

        private static Vector2 pMovementVector2;
        private Vector2 playerSpeed;
        private float jumpingCooldown;

        public void Update() // anything receives input should be inside update instead of fixedUpdate
        {
            if (CheckIfGrounded() && jumpingCooldown < 0.25f)
                jumpingCooldown += Time.deltaTime;
            if (jumpingCooldown >= 0.25f)
                pMovementVector2.y = Input.GetAxisRaw("Vertical");

            if (pMovementVector2.x == 0 && pMovementVector2.y == 0) return; // check here !
            PlayerAnimator.SetBool(PlayerMouseHandler.IsLanternUsed, false);
            LightIntensityController.LanternState = LanternFlickState.Idle;
        }

        private void FixedUpdate()
        {
            playerSpeed = rbPlayer.velocity;

            MoveCharacter();
        }

        private void MoveCharacter()
        {
            if (CheckIfGrounded())
            {
                if (PlayerAnimator.GetBool(IsJumping))
                {
                    pMovementVector2.y = 0f;
                    jumpingCooldown = 0f; // convert it reversely (initial time be 0.25f)
                }
                
                PlayerAnimator.SetBool(IsJumping, false);
                PlayerAnimator.SetBool(IsGrounded, true);
            }
            else
            {
                PlayerAnimator.SetBool(IsJumping, true);
                PlayerAnimator.SetBool(IsGrounded, false);
            }

            // move the rigidBody2D instead of moving the transform to prevent camera shaking 
            //..during wall contact
            if (pMovementVector2.y > 0.1f && CheckIfGrounded())
            {
                rbPlayer.velocity = new Vector2(playerSpeed.x, pJumpSpeedConstant);
                PlayerAnimator.SetTrigger(TakeOff);
            }

            AnimateRunning(); // can be on fixedUpdate
        }

        private void AnimateRunning()
        {
            PlayerAnimator.SetFloat(SpeedY, playerSpeed.y);
        }

        private bool CheckIfGrounded()
        {
            // understand this later
            var bCBounds = CapsuleCollider.bounds;
            RaycastHit2D raycastHit2D = Physics2D.BoxCast(bCBounds.center, bCBounds.size,
                0f, Vector2.down, 0.1f, PlatformsLayerMask);
            return !ReferenceEquals(raycastHit2D.collider, null); // changed from raycastHit2D.collider != null;
        }
    }

}