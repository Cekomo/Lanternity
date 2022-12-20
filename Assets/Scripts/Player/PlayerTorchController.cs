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

        private Vector2[] torchLocations;
        private Vector2 torchDefaultLocation;
        private int locationIndex;
        private float torchTime;


        void Start()
        {
            torchLight = torch.GetComponent<Light2D>();

            torchLocations = new Vector2[8];

            torchDefaultLocation = TorchAttributesSO.TorchCoordinateOnIdle;
            for (var i = 0; i < 8; i++)
                torchLocations[i] = TorchAttributesSO.TorchCoordinatesOnRunning[i];

            StartCoroutine(FlickTorch());
        }


        public void Update()
        {
            torchTime += Time.deltaTime;
            print(PlayerMovement.isGrounded);
            if (Mathf.Abs(PlayerMovement.pMovementVector2.x) > 0.1f && PlayerMovement.isGrounded)
            {
                RunWithTorch();
            }
            else
            {
                torch.transform.localPosition = torchDefaultLocation;
                locationIndex = 0;
            }
        }

        private void RunWithTorch() // there are synchronization problems between sprite frame and light
        {
            // convert it to coroutine
            // synchronization is mostly fixed but still slight offset exists between light & animation
            // approximately 104 mseconds per frame
            if (torchTime >= 0.104f)
            {
                torch.transform.localPosition = torchLocations[locationIndex];
                locationIndex++;
                torchTime = 0f;
                if (locationIndex == 8) locationIndex = 0;
            }
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
    }
}