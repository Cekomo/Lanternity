using Light;
using UnityEngine;

namespace Lantern
{
    public class SpiritDetector : MonoBehaviour
    {
        private void OnTriggerStay2D(Collider2D col)
        {
            if (!col.gameObject.CompareTag("Spirit") || 
                LightIntensityController.LanternState == LanternFlickState.CatchSpirit) return;
            
            LightIntensityController.LanternState = LanternFlickState.DetectSpirit;
        }
        
        private void OnTriggerExit2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Spirit") || 
                LightIntensityController.LanternState == LanternFlickState.CatchSpirit) return;
            
            LightIntensityController.LanternState = LanternFlickState.Idle;
        }
    }
}
