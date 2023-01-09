using UnityEngine.Rendering.Universal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using Light;

namespace Lantern 
{
    public class LanternStateController : MonoBehaviour
    {
        [SerializeField] private Animator playerAnimator;
        [SerializeField] private Light2D lanternLight;

        private void Update()
        {
            if (playerAnimator.GetBool(PlayerMouseHandler.IsLanternUsed))
            {
                LightIntensityController.LanternState = LanternFlickState.UsingLantern;
                PlayerHandController.playerCarryState = PlayerCarryState.UseLantern;
            }

            lanternLight.pointLightOuterRadius = 
                LightIntensityController.LanternState == LanternFlickState.UsingLantern ? 12f : 5f;

            if (Input.GetMouseButtonDown(0) && LightIntensityController.LanternState == LanternFlickState.UsingLantern)
                LightIntensityController.LanternState = LanternFlickState.Idle;

            if (PlayerProperties.CheckIfPlayerMoving()) return; // check here !
            playerAnimator.SetBool(PlayerMouseHandler.IsLanternUsed, false);
            LightIntensityController.LanternState = LanternFlickState.Idle;
        }
    }
}
