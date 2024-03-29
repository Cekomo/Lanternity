using UnityEngine;
using Light;
using Lantern;
using UnityEditor.PackageManager;

namespace Player
{
    public class PlayerMovementY : PlayerProperties
    {
        private static readonly int SpeedY = Animator.StringToHash("SpeedY");
        
        private static readonly int TakeOff = Animator.StringToHash("takeOff");
        private static readonly int IsJumping = Animator.StringToHash("isJumping");
        private static readonly int IsGrounded = Animator.StringToHash("isGrounded");

        private const float JUMPING_SPEED = 20f;
        private float jumpingCooldown;

        // private Vector2 playerSpeed;
        private static float movementVector2_Y;

        public void Update() // anything receives input should be inside update instead of fixedUpdate
        {
            AllowJumpConsideringCooldown();
        }

        private void FixedUpdate()
        {            
            ResetValuesIfPlayerJumped();
            JumpPlayer();
        }

        private void JumpPlayer()
        {
            SetParametersToAnimateJump(); // can be on fixedUpdate

            // move the rigidBody2D instead of moving the transform to prevent camera shaking 
            //..during wall contact
            if (!(movementVector2_Y > 0.1f) || !CheckIfGrounded() 
                || PlayerHandController.playerCarryState == PlayerCarryState.ActivateLanternBeam) return;
            rbPlayer.velocity = new Vector2(GetPlayerVelocity().x, JUMPING_SPEED);
            PlayerAnimator.SetTrigger(TakeOff);
        }

        private void AllowJumpConsideringCooldown()
        {
            if (jumpingCooldown >= 0.25f)
                movementVector2_Y = Input.GetAxisRaw("Vertical");
            else if (CheckIfGrounded())
                jumpingCooldown += Time.deltaTime; // !this variable only got reset when jumping is triggered!
        }
        
        private void ResetValuesIfPlayerJumped()
        {
            if (!PlayerAnimator.GetBool(IsJumping)) return;
            movementVector2_Y = 0f;
            jumpingCooldown = 0f; // convert it reversely (initial time be 0.25f)
        }
        
        private void SetParametersToAnimateJump()
        {
            PlayerAnimator.SetBool(IsJumping, !CheckIfGrounded());
            /*if (!CheckIfGrounded())*/ PlayerAnimator.SetBool(IsGrounded, CheckIfGrounded());
            PlayerAnimator.SetFloat(SpeedY, GetPlayerVelocity().y);
        }

        private bool CheckIfGrounded()
        {
            var bCBounds = CapsuleCollider.bounds;
            var raycastHit2D = Physics2D.BoxCast(bCBounds.center, bCBounds.size,
                0f, Vector2.down, 0.1f, PlatformsLayerMask);
            // var heightDifference = transform.position.y - raycastHit2D.point.y;
            // if (heightDifference < 1f) PlayerAnimator.SetBool(IsGrounded, true);
            return !ReferenceEquals(raycastHit2D.collider, null); // changed from raycastHit2D.collider != null;
        }
    }

}