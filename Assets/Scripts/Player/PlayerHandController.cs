using Lantern;
using UnityEngine;

namespace Player
{
    public class PlayerHandController : MonoBehaviour
    {
        public static PlayerCarryState playerCarryState;
        
        private Rigidbody2D rbPlayer;
        
        [SerializeField] private GameObject torch;
        [SerializeField] private GameObject lantern;
        [SerializeField] private Animator lightItemAnimator;

        public static readonly int IsLanternPicked = Animator.StringToHash("isLanternPicked");
        
        private bool isLanternPicked;

        private void Start()
        {
            rbPlayer = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Q) || !PickableLanternController.IsLanternPicked()
                || rbPlayer.velocity.x != 0 || rbPlayer.velocity.y != 0) return;

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
                isLanternPicked = false;
                lightItemAnimator.SetBool(IsLanternPicked, false);
                playerCarryState = PlayerCarryState.CarryTorch; // using it before isLanternPicked causes miscall
            }
            else
            {
                lantern.SetActive(true);
                isLanternPicked = true;
                lightItemAnimator.SetBool(IsLanternPicked, true);
                playerCarryState = PlayerCarryState.CarryLantern;
            }
        }
    }
}
