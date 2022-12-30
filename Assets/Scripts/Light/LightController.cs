using UnityEngine;

namespace Light
{
    public class LightController : MonoBehaviour
    {
        public LightIntensityController lightIntensityController;
        // private ILightController iLightController;
        
        private void Start()
        {
            lightIntensityController.FlickAllLights();
        }
    }
}