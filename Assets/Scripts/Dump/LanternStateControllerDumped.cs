using UnityEngine.Rendering.Universal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using Light;

namespace Lantern 
{
    public class LanternStateControllerDumped : MonoBehaviour
    {
        [SerializeField] private Animator playerAnimator;
        [SerializeField] private Light2D lanternLight;s

        private void Update()
        {
            if (PlayerHandController.playerCarryState == PlayerCarryState.UseLantern)
            {
                playerAnimator.SetBool(PlayerMouseHandler.IsLanternUsed, true);
                lanternLight.pointLightOuterRadius = 12f;
                if(Input.GetMouseButtonDown(0)) LightIntensityController.LanternState = LanternFlickState.Idle;
            }
            else
            {
                playerAnimator.SetBool(PlayerMouseHandler.IsLanternUsed, false);
                lanternLight.pointLightOuterRadius = 5f;
            }

            // lanternLight.pointLightOuterRadius = 
            //     PlayerHandController.playerCarryState == PlayerCarryState.UseLantern ? 12f : 5f;

            // if (Input.GetMouseButtonDown(0) && PlayerHandController.playerCarryState == PlayerCarryState.UseLantern)
            //     LightIntensityController.LanternState = LanternFlickState.Idle;

            if (!PlayerProperties.CheckIfPlayerMoving()) return; // check here !
            playerAnimator.SetBool(PlayerMouseHandler.IsLanternUsed, false);
            LightIntensityController.LanternState = LanternFlickState.Idle;
            PlayerHandController.playerCarryState = PlayerCarryState.CarryLantern;
        }
    }
}