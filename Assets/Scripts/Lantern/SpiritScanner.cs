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
        // private List<CircleCollider2D> spiritColliders;

        private Collider2D[] spiritColliders;
        private SpriteRenderer[] spiritSprites;
        
        private float scanCooldown;
        private float scannerRadius; 

        private void Start()
        {
            scannerRadius = GetComponent<CircleCollider2D>().radius;
            spiritColliders = new Collider2D[spiritController.spirits.Count];
            spiritSprites = new SpriteRenderer[spiritController.spirits.Count];

            for (var i = 0; i < spiritController.spirits.Count; i++)
                spiritSprites[i] = spiritController.spirits[i].GetComponent<SpriteRenderer>();
            for (var i = 0; i < spiritController.spirits.Count; i++)
                spiritColliders[i] = spiritController.spirits[i].GetComponent<Collider2D>();
        }

        private void Update()
        {
            // print(scanCooldown);
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
            var numColliders = Physics2D.OverlapCircleNonAlloc(transform.position, scannerRadius, spiritColliders);
            
            for (var i = 0; i < numColliders; i++)
            {
                var thecollider = spiritColliders[i];
                var thespirit = thecollider.gameObject;
                var spriteRenderer = thespirit.GetComponent<SpriteRenderer>();
                spriteRenderer.enabled = true;

                // spiritSprites[i].enabled = false;
            }
        }
        
    }

}
// for (var i = 0; i < spiritColliders.Length; i++)
// if (Physics2D.OverlapCircleNonAlloc(transform.position, scannerRadius, spiritColliders) == i)
// {
//     spiritController.spirits[i].SetActive(true);
// }