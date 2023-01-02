// using System.Collections;
// using System.Collections.Generic;
// using Light;
// using UnityEngine;
//
// namespace Dump
// {
//     public class LanternMouseHandler : LightIntensityController
//     {
//         private const float LanternLightIntensity = 3.0f;
//
//         public override void FlickLanternLight()
//         {
//             StartCoroutine(FlickUsingLanternLightCoroutine());
//             // print("flickoverriden");
//         }
//     
//         public override void StopFlickingLanternLight()
//         {
//             StopCoroutine(FlickUsingLanternLightCoroutine());
//             // print("stopflickoverriden");
//         }
//         
//         private IEnumerator FlickUsingLanternLightCoroutine()
//         {
//             while (true)
//             {
//                 FlickeringTimeDelay = Random.Range(0.07f, 0.15f);
//                 yield return new WaitForSeconds(FlickeringTimeDelay);
//                 lanternLight.intensity = Random.Range(LanternLightIntensity - 0.3f, LanternLightIntensity + 0.3f);
//             }
//         }
//     }
//
// }