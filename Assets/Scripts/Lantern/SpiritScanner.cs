using System;
using System.Collections;
using System.Collections.Generic;
using Spirit;
using UnityEngine;

namespace Lantern
{
    public class SpiritScanner : MonoBehaviour
    {
        public SpiritController spiritController;
        
        private void OnTriggerStay2D(Collider2D other)
        {
            if (!Input.GetKey(KeyCode.Z)) return;
            
            if (gameObject.CompareTag("Spirit"))
            {
                // set triggered spirit as visible
            }
        }
    }

}