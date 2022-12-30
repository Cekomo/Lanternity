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
        private List<float> lightIntensities;

        private void Start()
        {
            lightIntensities = new List<float>();
            foreach (var theLight in lights)
                lightIntensities.Add(theLight.intensity);
            // do not forget that it is not possible to firsly initialize an element by assigning
            // C# does not allow this functionality
        }
        
        public void FlickAllLights()
        {
            for (var i = 0; i < lights.Count; i++)
            {
                StartCoroutine(FlickLightCoroutine(lights[i], lightIntensities[i]));
            }
        }
        
        private IEnumerator FlickLightCoroutine(Light2D theLight, float lightIntensity)
        {
            while (true)
            {
                flickeringTimeDelay = Random.Range(0.07f, 0.15f);
                yield return new WaitForSeconds(flickeringTimeDelay);
                theLight.intensity = Random.Range(lightIntensity - 0.2f, lightIntensity + 0.2f);
            }
        }
    }
}