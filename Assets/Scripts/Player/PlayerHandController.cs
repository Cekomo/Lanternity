using Lantern;
using UnityEngine;

namespace Player
{
    public class PlayerHandController : MonoBehaviour
    {
        public static PlayerCarryState playerCarryState;

        [SerializeField] private GameObject torch;
        [SerializeField] private GameObject lantern;
        [SerializeField] private Animator lightItemAnimator;

        public static readonly int IsLanternPicked = Animator.StringToHash("isLanternPicked");
        
        private bool isLanternPicked;

        private void Update()
        {
            //HERE!-----------------------
            if (!Input.GetKeyDown(KeyCode.Q) || !PickableLanternController.IsLanternPicked()
                || PlayerProperties.CheckIfPlayerMoving()) return;

            SwitchBetweenLights();
        }

        private void SwitchBetweenLights()
        {
            torch.SetActive(false);
            lantern.SetActive(false);
            lightItemAnimator.SetBool(PlayerMouseHandler.IsLanternUsed, false);
            
            if (isLanternPicked)
            {
                torch.SetActive(true);
                lightItemAnimator.SetBool(IsLanternPicked, false);
                playerCarryState = PlayerCarryState.CarryTorch; 
                isLanternPicked = false;
            }
            else
            {
                lantern.SetActive(true);
                lightItemAnimator.SetBool(IsLanternPicked, true);
                playerCarryState = PlayerCarryState.CarryLantern;
                isLanternPicked = true;
            }
        }
    }
}
