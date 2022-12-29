using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Light
{ // shape this into interface structure
    public class LightIntensityController : MonoBehaviour, ILightController
    {
        private float flickeringTimeDelay;

        [SerializeField] private List<Light2D> lights;

        public void FlickLight()
        {
            foreach (var theLight in lights)
            {
                StartCoroutine(FlickLightCoroutine(theLight));
            }
        }
        
        private IEnumerator FlickLightCoroutine(Light2D theLight)
        {
            while (true)
            {
                flickeringTimeDelay = Random.Range(0.03f, 0.15f);
                yield return new WaitForSeconds(flickeringTimeDelay);
                theLight.intensity = Random.Range(theLight.intensity - 0.2f, theLight.intensity + 0.2f); // efficiency?
            }
        }
    }
}