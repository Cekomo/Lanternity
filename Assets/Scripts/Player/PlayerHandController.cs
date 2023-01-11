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

            lightItemAnimator.SetBool(PlayerMouseHandler.IsLanternUsed, false);
            SwitchBetweenLights();
        }

        private void SwitchBetweenLights()
        {
            isLanternPicked = !isLanternPicked;
            
            torch.SetActive(!isLanternPicked);
            lantern.SetActive(isLanternPicked);
            
            playerCarryState = isLanternPicked ? 
                PlayerCarryState.CarryLantern : PlayerCarryState.CarryTorch;

            lightItemAnimator.SetBool(IsLanternPicked, isLanternPicked);
        }
    }
}
