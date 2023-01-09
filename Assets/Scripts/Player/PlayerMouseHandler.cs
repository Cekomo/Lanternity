using Lantern;
using Light;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Player
{
    public class PlayerMouseHandler : MonoBehaviour
    {
        [SerializeField] private Animator playerAnimator;
        private Rigidbody2D rbPlayer;
        
        public static readonly int IsLanternUsed = Animator.StringToHash("isLanternUsed");

        private void Start()
        {
            rbPlayer = GetComponent<Rigidbody2D>();
        }

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