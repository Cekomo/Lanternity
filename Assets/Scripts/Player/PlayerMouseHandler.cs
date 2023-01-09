using UnityEngine;

namespace Player
{
    public class PlayerMouseHandler : MonoBehaviour
    {
        [SerializeField] private Animator playerAnimator;

        public static readonly int IsLanternUsed = Animator.StringToHash("isLanternUsed");

        private void Update()
        {
            SwitchLanternUsageWhenPressed();
        }

        private void SwitchLanternUsageWhenPressed()
        {
            if (!Input.GetMouseButtonDown(0) || PlayerProperties.CheckIfPlayerMoving() 
                || !playerAnimator.GetBool(PlayerHandController.IsLanternPicked)) return;
            
            playerAnimator.SetBool(IsLanternUsed, !playerAnimator.GetBool(IsLanternUsed));
        }
    }

}