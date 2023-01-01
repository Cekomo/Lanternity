using UnityEngine;

namespace Light
{
    public class PickableLanternController : MonoBehaviour
    {
        private static bool lanternPicked;
        private Animator lanternAnimator;
        
        // it is not necessary to define this boolean as hash variable
        private static readonly int LanternPickedUp = Animator.StringToHash("lanternPickedUp");

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

            lanternAnimator.SetBool(LanternPickedUp, true); // this can be adjusted
            lanternPicked = true;
            gameObject.SetActive(false);
        }
    }

}