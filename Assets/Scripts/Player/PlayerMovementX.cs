using UnityEngine;

namespace Player
{
    public class PlayerMovementX : PlayerProperties
    {
        private static readonly int SpeedX = Animator.StringToHash("SpeedX");

        private const float RUNNING_SPEED = 8f;
        private const float WALKING_SPEED = 5f;

        private float previousMoveX;
        private static float movementVector2_X;
        private Vector2 playerSpeed;

        public static PlayerMovementState playerMovementState;
        
        void Update()
        {
            movementVector2_X = Input.GetAxisRaw("Horizontal");
            print(movementVector2_X);
            switch (PlayerHandController.playerCarryState)
            {
                case PlayerCarryState.CarryTorch:
                    playerMovementState = movementVector2_X == 1 
                        ? PlayerMovementState.RunningRight : PlayerMovementState.RunningLeft;
                    break;
                case PlayerCarryState.CarryLantern:
                    playerMovementState = movementVector2_X == 1 
                        ? PlayerMovementState.WalkingRight : PlayerMovementState.WalkingLeft;
                    break;
                case PlayerCarryState.UseLantern:
                    PlayerHandController.playerCarryState = movementVector2_X != 0
                        ? PlayerCarryState.CarryLantern : PlayerCarryState.UseLantern;
                    break;
            }

            if (movementVector2_X != 0)
                PlayerAnimator.SetBool(PlayerMouseHandler.IsLanternUsed, false);
        }

        void FixedUpdate()
        {
            playerSpeed = rbPlayer.velocity; // convert it to X axis if possible
            
            MoveCharacterX();
        }

        private void MoveCharacterX()
        {
            // left right directions will be adjusted after direction-sensitive
            //..animations are added
            PlayerAnimator.SetFloat(SpeedX, Mathf.Abs(movementVector2_X));
            
            switch (playerMovementState)
            {
                case PlayerMovementState.Idle:
                    break;
                case PlayerMovementState.RunningLeft:
                    rbPlayer.velocity = new Vector2(movementVector2_X * RUNNING_SPEED, playerSpeed.y);
                    break;
                case PlayerMovementState.RunningRight:
                    rbPlayer.velocity = new Vector2(movementVector2_X * RUNNING_SPEED, playerSpeed.y);
                    break;
                case PlayerMovementState.WalkingLeft:
                    rbPlayer.velocity = new Vector2(movementVector2_X * WALKING_SPEED, playerSpeed.y);
                    break;
                case PlayerMovementState.WalkingRight:
                    rbPlayer.velocity = new Vector2(movementVector2_X * WALKING_SPEED, playerSpeed.y);
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