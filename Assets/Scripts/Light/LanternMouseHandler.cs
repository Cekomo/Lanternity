using System;
using Light;
using Player;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Light
{
    public class LanternMouseHandler : MonoBehaviour
    {
        [SerializeField] private Light2D lanternLight;

        private void Update() // refactor it
        {
            lanternLight.pointLightOuterRadius = PlayerMouseHandler.LanternUsageStatus ? 12 : 5;
            // lanternLight.falloffIntensity = PlayerMouseHandler.LanternUsageStatus ? falloffIntensity : falloffIntensity+0.1f;
        }
    }

}