using System;
using UnityEngine;

namespace Light
{
    public class PickableLanternController : MonoBehaviour
    {
        private static bool lanternPicked;
        private Animator lanternAnimator;

        private void Start()
        {
            lanternAnimator = GetComponent<Animator>();
        }

        public static bool IsLanternPicked()
        {
            return lanternPicked;
        }
        
        private void OnTriggerStay2D(Collider2D col)
        {
            if (!col.CompareTag("Player") || !Input.GetKey(KeyCode.E)) return;

            lanternAnimator.SetBool("lanternPickedUp", true); // this can be adjusted
            lanternPicked = true;
            gameObject.SetActive(false);
        }
    }

}