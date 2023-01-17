using UnityEngine;
using Light;
using Player;

namespace Lantern
{
    public class SpiritCatcher : MonoBehaviour
    {
        public SpiritScanner spiritScanner;

        private void OnTriggerStay2D(Collider2D col)
        {
            if (!col.gameObject.CompareTag("Spirit") || 
                PlayerHandController.playerCarryState != PlayerCarryState.ActivateLanternBeam) return;
            
            var spriteRenderer = col.gameObject.GetComponent<SpriteRenderer>();
            if (spriteRenderer.enabled)
                col.gameObject.SetActive(false);
            // not finished...
            // LightIntensityController.LanternState = LanternFlickState.CatchSpirit;
        }
    }
}
