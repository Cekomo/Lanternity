using Player;
using UnityEngine;

namespace Light
{
    public class LightController : MonoBehaviour // use it to initialize class and implement functions only
    {
        // [SerializeField] private Animator playerAnimator;
        public LightIntensityController lightIntensityController;
        private ILightController iLightController;

        private void Start()
        {
            iLightController = lightIntensityController;
            iLightController.FlickAllExternalLights();
            iLightController.FlickLanternLight();
        }

    }
}