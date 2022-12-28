using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Player
{
    public class LightIntensityController : MonoBehaviour
    {
        // [SerializeField] private GameObject theLight;
        private Light2D light2d;
        private float lightIntensity;
        private float flickeringTimeDelay;
        
        void Start()
        {
            light2d = GetComponent<Light2D>();
            lightIntensity = light2d.intensity;
            
            StartCoroutine(FlickLight());
        }

        private IEnumerator FlickLight()
        {
            while (true)
            {
                flickeringTimeDelay = Random.Range(0.03f, 0.15f);
                yield return new WaitForSeconds(flickeringTimeDelay);
                light2d.intensity = Random.Range(lightIntensity - 0.2f, lightIntensity + 0.2f);
            }
        }
    }
}