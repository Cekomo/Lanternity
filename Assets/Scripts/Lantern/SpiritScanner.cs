using Spirit;
using UnityEngine;

namespace Lantern
{
    public class SpiritScanner : MonoBehaviour
    {
        public SpiritController spiritController;

        private SpriteRenderer[] spiritSprites;

        private float scanCooldown;
        private float scannerRadius; // 6 unit seems suitable

        private void Start()
        {   // when I drop scannerRadius to 6, it does not scan, it scans for greater values
            scannerRadius = GetComponent<CircleCollider2D>().radius - 10; 
            
            spiritSprites = new SpriteRenderer[spiritController.spirits.Count];
            for (var i = 0; i < spiritController.spirits.Count; i++)
                spiritSprites[i] = spiritController.spirits[i].GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            if (scanCooldown > 0)
            {
                scanCooldown -= Time.deltaTime;
                return;
            }
            
            ScanSpirit();
        }
        
        private void ScanSpirit()
        {
            if (!Input.GetKey(KeyCode.Z)) return;
            
            scanCooldown = 2f;

            var i = 0;
            foreach (var spirit in spiritController.spirits)
            {
                var spiritLanternDistance = Vector3.Distance(transform.position, spirit.transform.position);

                if (spiritLanternDistance <= scannerRadius)
                    spiritSprites[i].enabled = true;
                
                i++;
            }
        }
    }
}