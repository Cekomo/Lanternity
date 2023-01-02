// using Player;
// using UnityEngine;
//
// namespace Dump
// {
//     public class LightController : MonoBehaviour // use it to initialize class and implement functions only
//     {
//         private bool isLanternToggled;
//         private bool isCoroutineCalled;
//
//         [SerializeField] private Animator playerAnimator;
//         public LightIntensityController lightIntensityController;
//         private LanternMouseHandler lanternMouseHandler;
//         private ILightController iLightController;
//
//         private void Start()
//         {
//             lanternMouseHandler = GetComponent<LanternMouseHandler>();
//             
//             iLightController = lightIntensityController;
//             iLightController.FlickAllExternalLights();
//             iLightController.FlickLanternLight();
//         }
//
//         private void Update()
//         {
//             if (Input.GetMouseButtonDown(0) && !playerAnimator.GetBool(PlayerMouseHandler.IsLanternUsed))
//                 isLanternToggled = true;
//             if (!playerAnimator.GetBool(PlayerMouseHandler.IsLanternUsed) && isCoroutineCalled)
//             {
//                 lanternMouseHandler.FlickLanternLight();
//                 lanternMouseHandler.StopFlickingLanternLight();
//                 iLightController.FlickLanternLight();
//                 isCoroutineCalled = !isCoroutineCalled;
//             }
//             
//             if (!playerAnimator.GetBool(PlayerMouseHandler.IsLanternUsed) || !isLanternToggled) return;
//
//             isLanternToggled = false;
//             isCoroutineCalled = true;
//
//             iLightController.FlickLanternLight();
//             iLightController.StopFlickingLanternLight();
//             lanternMouseHandler.FlickLanternLight();
//         }
//     }
// }