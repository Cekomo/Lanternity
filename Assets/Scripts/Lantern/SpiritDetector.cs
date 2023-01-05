using UnityEngine;

namespace Lantern
{
    public class SpiritDetector : MonoBehaviour
    {
        public static bool IsSpiritDetected;
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Spirit"))
                IsSpiritDetected = true;
        }
        
        private void OnTriggerExit2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Spirit"))
                IsSpiritDetected = false;
        }
    }
}
