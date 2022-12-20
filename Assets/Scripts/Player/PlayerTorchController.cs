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
        
        void Start()
        {
            torchLight = torch.GetComponent<Light2D>();
            
            StartCoroutine(FlickTorch());
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