using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Player
{
    public class PlayerTorchController : MonoBehaviour
    {
        [SerializeField] private GameObject torch;
        private Light2D torchLight;
        private float flickeringTimeDelay;
        
        private Vector2 torchCoordinateOnIdle;
        private Vector2[] torchCoordinatesOnRunning;
        private Vector2[] torchCoordinatesOnTakingOff;
        private Vector2[] torchCoordinatesOnJumping;
        private Vector2[] torchCoordinatesOnLanding;

        private int locationIndex;
        private float torchMovementTimer;

        private float landingAnimationExitTimer; 
        
        void Start()
        {
            torchLight = torch.GetComponent<Light2D>();

            torchCoordinatesOnRunning = new Vector2[8];
            torchCoordinatesOnTakingOff = new Vector2[5];
            torchCoordinatesOnJumping = new Vector2[3];
            torchCoordinatesOnLanding = new Vector2[7];

            torchCoordinateOnIdle = TorchAttributesSO.TorchCoordinateOnIdle;
            for (var i = 0; i < 8; i++)
                torchCoordinatesOnRunning[i] = TorchAttributesSO.TorchCoordinatesOnRunning[i];
            for (var i = 0; i < 5; i++)
                torchCoordinatesOnTakingOff[i] = TorchAttributesSO.TorchCoordinatesOnTakingOff[i];
            for (var i = 0; i < 3; i++)
                torchCoordinatesOnJumping[i] = TorchAttributesSO.TorchCoordinatesOnJumping[i];
            for (var i = 0; i < 7; i++)
                torchCoordinatesOnLanding[i] = TorchAttributesSO.TorchCoordinatesOnLanding[i];

            StartCoroutine(FlickTorch());
        }


        public void Update()
        {
            torchMovementTimer += Time.deltaTime; print(locationIndex);
            
            if (Mathf.Abs(PlayerMovement.pMovementVector2.x) > 0.1f && PlayerMovement.isGrounded)
            {
                RunWithTorch();
            }
            else
            {
                torch.transform.localPosition = torchCoordinateOnIdle;
                locationIndex = 0;
            }

            WaitLandingAnimationForTorchMovement();
        }
        
        private void RunWithTorch() // there are synchronization problems between sprite frame and light
        {
            // convert it to coroutine
            // synchronization is mostly fixed but still slight offset exists between light & animation
            // approximately 104 mseconds per frame
            
            if (torchMovementTimer >= 0.104f && landingAnimationExitTimer < 0)
            {
                torch.transform.localPosition = torchCoordinatesOnRunning[locationIndex];
                locationIndex++;
                torchMovementTimer = 0f;
                if (locationIndex == 8) locationIndex = 0;
            }
        }

        private void JumpWithTorch()
        {
            // if (locationIndex < 5 && torchMovementTimer >= 0.07f)
            // {
            //     torch.transform.localPosition = torchCoordinatesOnTakingOff[locationIndex];
            //     locationIndex++;
            //     torchMovementTimer = 0f;
            // }
            // else if (locationIndex > 4 && torchMovementTimer >= 0.061f)
            // {
            //     torch.transform.localPosition = torchCoordinatesOnJumping[locationIndex-5];
            //     locationIndex++;
            //     torchMovementTimer = 0f;
            // }
            // else if (locationIndex > 7 && torchMovementTimer >= 0.045f)
            // {
            //     torch.transform.localPosition = torchCoordinatesOnLanding[locationIndex-8];
            //     locationIndex++;
            //     torchMovementTimer = 0f;
            // }
        }

        private IEnumerator FlickTorch()
        {
            while (true)
            {
                flickeringTimeDelay = Random.Range(0.03f, 0.2f);
                yield return new WaitForSeconds(flickeringTimeDelay);
                torchLight.intensity = Random.Range(1.6f, 2f);
            }
        }
        
        private void WaitLandingAnimationForTorchMovement()
        {
            if (!PlayerMovement.isGrounded)
            {
                landingAnimationExitTimer = 0.3f;
                torch.transform.localPosition = torchCoordinatesOnJumping[2];
            }
            else
                landingAnimationExitTimer -= Time.deltaTime;
            
            if (landingAnimationExitTimer is > 0 and < 0.3f) // you do not know this structure
                torch.transform.localPosition = torchCoordinateOnIdle;
        }
    }
}