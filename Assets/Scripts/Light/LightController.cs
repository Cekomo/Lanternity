using UnityEngine;

namespace Light
{
    public class LightController : MonoBehaviour // use it to initialize class and implement functions only
    {
        public LightIntensityController lightIntensityController;
        private ILightController iLightController;
        
        private void Start()
        {
            iLightController = lightIntensityController;
            iLightController.FlickAllLights();
        }
    }
}