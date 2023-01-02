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

        public void FlickLanternLight()
        {
            StartCoroutine(FlickLanternLightCoroutine());
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

        private IEnumerator FlickLanternLightCoroutine()
        {
            while (true)
            {
                flickeringTimeDelay = Random.Range(0.07f, 0.15f);
                yield return new WaitForSeconds(flickeringTimeDelay);
                
                lanternLight.intensity = !PlayerMouseHandler.LanternUsageStatus ? 
                    Random.Range(LanternLightIntensity - 0.3f, LanternLightIntensity + 0.3f) :
                    Random.Range(1.75f - 0.3f, 1.75f + 0.3f);
            }
        }
        
    }
}