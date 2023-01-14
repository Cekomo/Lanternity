using UnityEngine;

namespace Player
{
    public class PlayerMouseHandler : MonoBehaviour
    {
        [SerializeField] private Animator playerAnimator;

        public static readonly int IsLanternUsed = Animator.StringToHash("isLanternUsed");
        private static bool isLanternUsed;

        private void Update()
        {
            print(isLanternUsed);   
            if ((!Input.GetMouseButtonDown(0) && !Input.GetMouseButtonDown(1)) 
                || PlayerProperties.CheckIfPlayerMoving()
                || !playerAnimator.GetBool(PlayerHandController.IsLanternPicked)) return;

            SwitchLanternUsageWhenPressed();
        }

        private void SwitchLanternUsageWhenPressed() // refactor this function
        {            
            if (!Input.GetMouseButtonDown(1)) isLanternUsed = !isLanternUsed;
            PlayerHandController.playerCarryState = 
                isLanternUsed ? PlayerCarryState.LiftLantern : PlayerCarryState.CarryLantern;
           
            if (!Input.GetMouseButton(1) || !isLanternUsed ||
                 PlayerHandController.playerCarryState != PlayerCarryState.LiftLantern) return;
            PlayerHandController.playerCarryState = PlayerCarryState.ActivateLanternBeam;
        }

        public static void ResetLanternUsageIfNotPicked(bool isLanternPicked)
        {
            if (!isLanternPicked || PlayerProperties.CheckIfPlayerMoving()) isLanternUsed = false;
            // if (PlayerProperties.CheckIfPlayerMoving()) isLanternUsed = false;
        }
    }

}