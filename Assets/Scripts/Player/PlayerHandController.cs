using System;
using Light;
using UnityEngine;

namespace Player
{
    public class PlayerHandController : MonoBehaviour
    {
        private Rigidbody2D rbPlayer;
        
        [SerializeField] private GameObject torch;
        [SerializeField] private GameObject lantern;
        [SerializeField] private Animator lightItemAnimator;

        private bool isLanternPicked;
        
        public static readonly int IsLanternUsed = Animator.StringToHash("isLanternUsed");
        public static readonly int IsLanternPicked = Animator.StringToHash("isLanternPicked");

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
            lightItemAnimator.SetBool(IsLanternUsed, false); 

            if (isLanternPicked)
            {
                torch.SetActive(true);
                isLanternPicked = false;
                lightItemAnimator.SetBool(IsLanternPicked, false);
            }
            else
            {
                lantern.SetActive(true);
                isLanternPicked = true;
                lightItemAnimator.SetBool(IsLanternPicked, true);
            }
        }
    }
}
