using System;
using Light;
using Player;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Lantern
{
    public class LanternMouseHandler : MonoBehaviour
    {
        [SerializeField] private Light2D lanternLight;

        private void Update() // refactor it
        {
            lanternLight.pointLightOuterRadius = 
                LightIntensityController.LanternState == LanternFlickState.UsingLantern ? 12f : 5f;
            
            if (Input.GetMouseButtonDown(0) && LightIntensityController.LanternState == LanternFlickState.UsingLantern)
                LightIntensityController.LanternState = LanternFlickState.Idle;
        }
    }

}