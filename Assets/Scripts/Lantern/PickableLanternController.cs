using System;
using UnityEngine;

namespace Lantern
{
    public class PickableLanternController : MonoBehaviour 
    {
        private void OnTriggerStay2D(Collider2D col)
        {
            if (!col.CompareTag("Player") || !Input.GetKey(KeyCode.E)) return;
            
            Destroy(gameObject);
        }
    }

}