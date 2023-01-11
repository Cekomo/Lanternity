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
        [SerializeField] private Light2D lanternLight;

        public delegate void LanternStateHandler();
        private LanternStateHandler currentStateHandler;

        private void Update()
        {
            // if a function needs to be added "+=/-=" keywords needs to be added
            switch (PlayerHandController.playerCarryState)
            {
                case PlayerCarryState.UseLantern:
                    currentStateHandler = UseLantern;
                    break;
                case PlayerCarryState.CarryLantern:
                    currentStateHandler = CarryLantern;
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
            lanternLight.pointLightOuterRadius = 12f;
            if(Input.GetMouseButtonDown(0)) LightIntensityController.LanternState = LanternFlickState.Idle;
        }

        private void CarryLantern()
        {
            playerAnimator.SetBool(PlayerMouseHandler.IsLanternUsed, false);
            lanternLight.pointLightOuterRadius = 5f;
        }
    }
}
