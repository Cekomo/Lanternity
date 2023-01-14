using UnityEngine;
using Light;
using Lantern;

namespace Player
{
    public class PlayerMovementX : PlayerProperties
    {
        private static readonly int SpeedX = Animator.StringToHash("SpeedX");

        private const float RUNNING_SPEED = 8f;
        private const float WALKING_SPEED = 6f;
        
        // private Vector2 playerSpeed;
        private static float movementVector2_X;
        private float previousMoveX;
        private static float playerFacing;

        private static PlayerMovementState playerMovementState;
        
        private void Update()
        {
            movementVector2_X = Input.GetAxisRaw("Horizontal");
            PlayerAnimator.SetFloat(SpeedX, Mathf.Abs(movementVector2_X));
        }

        private void FixedUpdate()
        {
            MovePlayerX();
        }

        private void MovePlayerX() // refactor this method after big picture is done
        {
            // left right directions will be adjusted after direction-sensitive
            //..animations are added
            
            switch (PlayerHandController.playerCarryState)
            {
                case PlayerCarryState.CarryTorch:
                    rbPlayer.velocity = new Vector2(movementVector2_X * RUNNING_SPEED, GetPlayerVelocity().y);
                    break;
                case PlayerCarryState.CarryLantern or PlayerCarryState.LiftLantern: // temporary place for UseLantern
                    rbPlayer.velocity = new Vector2(movementVector2_X * WALKING_SPEED, GetPlayerVelocity().y);
                    break;
                default:
                    print("Unwanted occurence!");    
                    break;
            }
            
            FaceTowards();
        }

        private void FaceTowards()
        {
            if ((int)previousMoveX == (int)movementVector2_X) return;
            DeterminePlayerDirection();
            
            if (movementVector2_X != 0)
                transform.localScale = new Vector3(2.15f * movementVector2_X, 2.15f, 1);

            previousMoveX = movementVector2_X;
        }

        public static float DeterminePlayerDirection()
        {
            if (movementVector2_X != 0) playerFacing = movementVector2_X;
            return playerFacing;
        }
    }
}