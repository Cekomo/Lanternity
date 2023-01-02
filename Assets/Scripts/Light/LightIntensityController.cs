using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Player;

namespace Light
{ // shape this into interface structure
    public class LightIntensityController : MonoBehaviour, ILightController
    {
        private float flickeringTimeDelay;

        [SerializeField] protected Light2D lanternLight;
        private float LanternLightIntensity;
        
        [SerializeField] private List<Light2D> lights;
        private List<float> lightIntensities;

        private void Start()
        {
            LanternLightIntensity = lanternLight.intensity;
            lightIntensities = new List<float>();
            foreach (var theLight in lights)
                lightIntensities.Add(theLight.intensity);
            // do not forget that it is not possible to firsly initialize an element by assigning
            // C# does not allow this functionality
        }
        
        public void FlickAllExternalLights()
        {
            for (var i = 0; i < lights.Count; i++)
            {
                StartCoroutine(FlickLightsCoroutine(lights[i], lightIntensities[i]));
            }
        }

        public void FlickLanternLight(float lanternLightIntensity)
        {
            StartCoroutine(FlickLanternLightCoroutine(lanternLightIntensity));
        }

        private IEnumerator FlickLightsCoroutine(Light2D theLight, float lightIntensity)
        {
            while (true)
            {
                flickeringTimeDelay = Random.Range(0.07f, 0.15f);
                yield return new WaitForSeconds(flickeringTimeDelay);
                theLight.intensity = Random.Range(lightIntensity - 0.2f, lightIntensity + 0.2f);
            }
        }

        private IEnumerator FlickLanternLightCoroutine(float lanternLightIntensity)
        {
            while (true)
            {
                flickeringTimeDelay = Random.Range(0.07f, 0.15f);
                yield return new WaitForSeconds(flickeringTimeDelay);

                lanternLight.intensity = !PlayerMouseHandler.LanternUsageStatus ? 
                    Random.Range(lanternLightIntensity - 0.3f, lanternLightIntensity + 0.3f) :
                    Random.Range(3 - 0.3f, 3 + 0.3f);
            }
        }
        
    }
}