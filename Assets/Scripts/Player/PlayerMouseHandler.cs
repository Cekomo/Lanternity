using Light;
using UnityEngine;

namespace Player
{
    public class PlayerMouseHandler : MonoBehaviour
    {
        // [SerializeField] private GameObject player;
        private Rigidbody2D rbPlayer;
        
        private void Start()
        {
            rbPlayer = GetComponent<Rigidbody2D>();
        }

        
        private void Update()
        {
            if (!Input.GetMouseButton(0) || rbPlayer.velocity.x > 0.1f || rbPlayer.velocity.y > 0.1f 
                || !PickableLanternController.IsLanternPicked()) return;
            
            print("mouse toggled while standing");
        }
    }

}