using UnityEngine.Rendering.Universal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using Light;

// NOTE: with refactoring flick pattern changes for UseLantern from passively 
//..blinking to aggressively

namespace Lantern 
{
    public class LanternStateController : MonoBehaviour
    {
        [SerializeField] private Animator playerAnimator;
        [SerializeField] private Light2D spotLight;
        [SerializeField] private Light2D beamLight;

        private delegate void LanternStateHandler();
        private LanternStateHandler currentStateHandler;

        private bool isStateChangeAvailable = true;
        
        private void Update()
        {
            if (!isStateChangeAvailable) return;
            
            // print(PlayerHandController.playerCarryState);
            // if a function needs to be added "+=/-=" keywords needs to be added
            switch (PlayerHandController.playerCarryState)
            {
                case PlayerCarryState.LiftLantern:
                    currentStateHandler += () => SetLanternBeamIntensity(0);
                    currentStateHandler += UseLantern;
                    break;
                case PlayerCarryState.CarryLantern:
                    currentStateHandler += () => SetLanternBeamIntensity(0);
                    currentStateHandler += CarryLantern;
                    break;
                case PlayerCarryState.ActivateLanternBeam:
                    currentStateHandler += () => SetLanternBeamIntensity(1.0f);
                    break;
                default:
                    currentStateHandler = null;
                    break;
            }
            
            currentStateHandler?.Invoke(); // used handle nullReference exception

            if (!PlayerProperties.CheckIfPlayerMoving()) return; // check here !
            PlayerHandController.playerCarryState = PlayerCarryState.CarryLantern;
        }

        private void UseLantern()
        {
            playerAnimator.SetBool(PlayerMouseHandler.IsLanternUsed, true);
            spotLight.pointLightOuterRadius = 12f;
            if(Input.GetMouseButtonDown(0)) LightIntensityController.LanternState = LanternFlickState.Idle;
        }

        private void CarryLantern()
        {
            playerAnimator.SetBool(PlayerMouseHandler.IsLanternUsed, false);
            spotLight.pointLightOuterRadius = 3f;
        }

        private void SetLanternBeamIntensity(float beamIntensity)
        {
            spotLight.pointLightOuterRadius = beamIntensity;
            beamLight.intensity = beamIntensity;

            if (LightIntensityController.LanternState != LanternFlickState.CatchSpirit) return;
            StartCoroutine(IncreaseLightBeamBrightness());
        }
        
        private IEnumerator IncreaseLightBeamBrightness()
        {
            yield return new WaitForSeconds(0.1f);
            beamLight.intensity = 10f;
            isStateChangeAvailable = false;
            yield return new WaitForSeconds(1f);
            
            LightIntensityController.LanternState = LanternFlickState.Idle;
            isStateChangeAvailable = true;
            beamLight.intensity = 1f;
           
        }
    }
}
