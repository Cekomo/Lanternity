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
            if (!Input.GetMouseButtonDown(0) || PlayerProperties.CheckIfPlayerMoving() 
                || !playerAnimator.GetBool(PlayerHandController.IsLanternPicked)) return;
            
            SwitchLanternUsageWhenPressed();
        }

        private void SwitchLanternUsageWhenPressed()
        {            
            isLanternUsed = !isLanternUsed;
            PlayerHandController.playerCarryState = 
                isLanternUsed ? PlayerCarryState.UseLantern : PlayerCarryState.CarryLantern;            
        }
    }

}