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
            if (isLanternPicked)
            {
                torch.SetActive(true);
                lantern.SetActive(false);
                isLanternPicked = false;
                lightItemAnimator.SetBool("isLanternPicked", false);
            }
            else
            {
                lantern.SetActive(true);
                torch.SetActive(false);
                isLanternPicked = true;
                lightItemAnimator.SetBool("isLanternPicked", true);
            }
        }
    }
}
