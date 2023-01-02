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
            torch.SetActive(false);
            lantern.SetActive(false);
            lightItemAnimator.SetBool("isLanternUsed", false); 

            if (isLanternPicked)
            {
                torch.SetActive(true);
                isLanternPicked = false;
                lightItemAnimator.SetBool("isLanternPicked", false);
            }
            else
            {
                lantern.SetActive(true);
                isLanternPicked = true;
                lightItemAnimator.SetBool("isLanternPicked", true);
            }
        }
    }
}
