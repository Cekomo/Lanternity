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
        
        private float scanCooldown;
        private float scannerRadius; 

        private void Start()
        {
            scannerRadius = GetComponent<CircleCollider2D>().radius;
            spiritColliders = new Collider2D[spiritController.spirits.Count];

            for (var i = 0; i < spiritController.spirits.Count; i++)
                spiritColliders[i] = spiritController.spirits[i].GetComponent<Collider2D>();
        }

        private void Update()
        {
            if (scanCooldown > 0)
            {
                scanCooldown -= Time.deltaTime;
                return;
            }

            print(scanCooldown);
            ScanSpirit();
        }
        
        private void ScanSpirit()
        {
            if (!Input.GetKey(KeyCode.Z)) return;

            scanCooldown = 10f;
            for (var i = 0; i < spiritColliders.Length; i++)
                if (Physics2D.OverlapCircleNonAlloc(transform.position, scannerRadius, spiritColliders, i) > 0)
                {
                    spiritController.spirits[i].SetActive(true);
                }
            
        }
        
    }

}