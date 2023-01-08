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

        private float previousMoveX;
        private static float movementVector2_X;
        private Vector2 playerSpeed;

        private static PlayerMovementState playerMovementState;
        
        void Update()
        {
            movementVector2_X = Input.GetAxisRaw("Horizontal");

            PlayerAnimator.SetFloat(SpeedX, Mathf.Abs(movementVector2_X));
            if (movementVector2_X != 0) // refactor this
                PlayerAnimator.SetBool(PlayerMouseHandler.IsLanternUsed, false);
            
            if (movementVector2_X == 0) return; // check here !
            PlayerAnimator.SetBool(PlayerMouseHandler.IsLanternUsed, false);
            LightIntensityController.LanternState = LanternFlickState.Idle;
        }

        void FixedUpdate()
        {
            playerSpeed = rbPlayer.velocity; // convert it to X axis if possible
            
            MovePlayerX();
        }

        private void MovePlayerX() // refactor this method after big picture is done
        {
            // left right directions will be adjusted after direction-sensitive
            //..animations are added
            switch (PlayerHandController.playerCarryState)
            {
                case PlayerCarryState.CarryTorch:
                    playerMovementState = movementVector2_X == 1 
                        ? PlayerMovementState.RunningRight : PlayerMovementState.RunningLeft;
                    rbPlayer.velocity = new Vector2(movementVector2_X * RUNNING_SPEED, playerSpeed.y);
                    break;
                case PlayerCarryState.CarryLantern:
                    playerMovementState = movementVector2_X == 1 
                        ? PlayerMovementState.WalkingRight : PlayerMovementState.WalkingLeft;
                    rbPlayer.velocity = new Vector2(movementVector2_X * WALKING_SPEED, playerSpeed.y);
                    break;
                case PlayerCarryState.UseLantern:
                    PlayerHandController.playerCarryState = movementVector2_X != 0
                        ? PlayerCarryState.CarryLantern : PlayerCarryState.UseLantern;
                    break;
            }
            
            FaceTowards();
        }

        private void FaceTowards()
        {
            if ((int)previousMoveX == (int)movementVector2_X) return;

            if (movementVector2_X != 0)
                transform.localScale = new Vector3(2.15f * movementVector2_X, 2.15f, 1);

            previousMoveX = movementVector2_X;
        }
    }
}