using System.Collections;
using System.Collections.Generic;
using Lantern;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Player;

namespace Light
{ // shape this into interface structure
    public class LightIntensityController : MonoBehaviour, ILightController
    {
        public static LanternFlickState LanternState;
        
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
            // do not forget that it is not possible to firstly initialize an element by assigning
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

        private IEnumerator FlickLanternLightCoroutine() // it is better to express flick states with enum
        {
            while (true)
            {
                flickeringTimeDelay = Random.Range(0.07f, 0.15f);
                yield return new WaitForSeconds(flickeringTimeDelay);

                ExecuteConsideringFlickState();
            }
        }

        private void ExecuteConsideringFlickState()
        {
            // new switch structure coming with c# 8.0
            lanternLight.intensity = LanternState switch
            {
                LanternFlickState.Idle => Random.Range(LanternLightIntensity - 0.3f, LanternLightIntensity + 0.3f),
                LanternFlickState.DetectingSpirit => Random.Range(LanternLightIntensity-0.8f, LanternLightIntensity+0.8f),
                LanternFlickState.UsingLantern => Random.Range(1.75f - 0.3f, 1.75f + 0.3f),
                _ => lanternLight.intensity
            };
        }
    }
}