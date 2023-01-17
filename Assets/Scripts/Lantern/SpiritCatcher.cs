using UnityEngine;
using Light;
using Player;

namespace Lantern
{
    public class SpiritCatcher : MonoBehaviour
    {
        public SpiritScanner spiritScanner;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.gameObject.CompareTag("Spirit")) return;
            
            foreach (var spiritSprite in spiritScanner.spiritSprites)
            {
                if (spiritSprite.enabled && PlayerHandController.playerCarryState == PlayerCarryState.ActivateLanternBeam)
                {
                    spiritSprite.enabled = false;
                    // LightIntensityController.LanternState = LanternFlickState.CatchSpirit;
                }
            }
            
        }
    }
}
