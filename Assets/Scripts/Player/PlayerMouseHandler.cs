using UnityEngine;

namespace Player
{
    public class PlayerMouseHandler : MonoBehaviour
    {
        [SerializeField] private Animator playerAnimator;

        public static readonly int IsLanternUsed = Animator.StringToHash("isLanternUsed");
        private bool isLanternUsed;

        private void Update()
        {
            SwitchLanternUsageWhenPressed();
        }

        private void SwitchLanternUsageWhenPressed()
        {
            if (!Input.GetMouseButtonDown(0) || PlayerProperties.CheckIfPlayerMoving() 
                || !playerAnimator.GetBool(PlayerHandController.IsLanternPicked)) return;
            
            isLanternUsed = !isLanternUsed;
            PlayerHandController.playerCarryState = 
                isLanternUsed ? PlayerCarryState.UseLantern : PlayerCarryState.CarryLantern;
            // if (isLanternUsed) PlayerHandController.playerCarryState = PlayerCarryState.UseLantern;
            // else PlayerHandController.playerCarryState = PlayerCarryState.CarryLantern;
            
        }
    }

}