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

        public delegate void LanternStateHandler();
        private LanternStateHandler currentStateHandler;

        private void Update()
        {
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
            
            if (currentStateHandler != null)
                currentStateHandler();

            if (!PlayerProperties.CheckIfPlayerMoving()) return; // check here !
            playerAnimator.SetBool(PlayerMouseHandler.IsLanternUsed, false);
            LightIntensityController.LanternState = LanternFlickState.Idle;
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
