using UnityEngine;

namespace Lantern
{
    public class PickableLanternController : MonoBehaviour 
    {
        public GameObject lantern;
        public Animator lanternAnimator;

        public bool isLanternPickedUp()
        {
            if (lanternAnimator.GetBool("lanternPickedUp")) lantern.SetActive(true); // check this
            return lanternAnimator.GetBool("lanternPickedUp");
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))
            {
                lanternAnimator.SetBool("lanternPickedUp", true);
                isLanternPickedUp();
            }
        }
    }

}