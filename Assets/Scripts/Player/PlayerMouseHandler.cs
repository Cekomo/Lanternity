using Light;
using UnityEngine;

namespace Player
{
    public class PlayerMouseHandler : MonoBehaviour
    {
        [SerializeField] private Animator playerAnimator;
        private Rigidbody2D rbPlayer;
        
        private void Start()
        {
            rbPlayer = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (!Input.GetMouseButtonDown(0) || rbPlayer.velocity.x > 0.1f || rbPlayer.velocity.y > 0.1f 
                || !playerAnimator.GetBool("isLanternPicked")) return;
            
            if (!playerAnimator.GetBool("isLanternUsed"))
                playerAnimator.SetBool("isLanternUsed", true);
            else
                playerAnimator.SetBool("isLanternUsed", false);
        }
    }

}