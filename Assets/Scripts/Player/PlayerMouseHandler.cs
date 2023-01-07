using Lantern;
using Light;
using UnityEngine;

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
            if (playerAnimator.GetBool(IsLanternUsed))
            {
                LightIntensityController.LanternState = LanternFlickState.UsingLantern;
                PlayerHandController.playerCarryState = PlayerCarryState.UseLantern;
            }
            
            SwitchLanternUsageWhenPressed();
        }

        private void SwitchLanternUsageWhenPressed()
        {
            if (!Input.GetMouseButtonDown(0) || rbPlayer.velocity.x > 0.1f || rbPlayer.velocity.y > 0.1f 
                || !playerAnimator.GetBool(PlayerHandController.IsLanternPicked)) return;
 
            playerAnimator.SetBool(IsLanternUsed, !playerAnimator.GetBool(IsLanternUsed));
        }
    }

}