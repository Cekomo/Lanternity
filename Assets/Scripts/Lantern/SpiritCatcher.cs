using UnityEngine;
using Light;
using Player;
using UserInterface;

namespace Lantern
{
    public class SpiritCatcher : MonoBehaviour
    {
        public SpiritCounterUI spiritCounterUI;
        
        private int spiritCaptured;
        
        private void OnTriggerStay2D(Collider2D col)
        {
            if (!col.gameObject.CompareTag("Spirit") || 
                PlayerHandController.playerCarryState != PlayerCarryState.ActivateLanternBeam) return;
            
            var spriteRenderer = col.gameObject.GetComponent<SpriteRenderer>();
            if (spriteRenderer.enabled)
                col.gameObject.SetActive(false);

            spiritCaptured++;
            spiritCounterUI.SetSpiritCaptured(spiritCaptured);
            
            LightIntensityController.LanternState = LanternFlickState.CatchSpirit;
        }
    }
}
