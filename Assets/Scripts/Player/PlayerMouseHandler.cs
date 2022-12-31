using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerMouseHandler : MonoBehaviour
    {
        // [SerializeField] private GameObject player;
        private Rigidbody2D rbPlayer;
        
        void Start()
        {
            rbPlayer = GetComponent<Rigidbody2D>();
        }

        
        void Update()
        {
            if (!Input.GetMouseButton(0) || rbPlayer.velocity.x > 0.1f || rbPlayer.velocity.y > 0.1f) return;
            
            print("mouse toggled while standing");
        }
    }

}