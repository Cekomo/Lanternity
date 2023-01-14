using Player;
using UnityEngine;

namespace Lantern
{
    public class LanternBeamController : MonoBehaviour
    {
        private Camera mainCamera;
        private const float ANGLE_THRESHOLD = 30;
        
        private void Start()
        {
            mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>(); // = Camera.main equivalent
        }
        
        private void Update()
        {
            if (!Input.GetMouseButton(1) || PlayerHandController.playerCarryState != 
                PlayerCarryState.ActivateLanternBeam) return;

            PointMouseWithBeam();
        }

        private void PointMouseWithBeam()
        {
            var mousePosition = Input.mousePosition;
            // Convert the mouse position from screen space to world space
            mousePosition = mainCamera.ScreenToWorldPoint(mousePosition);
            var direction = (mousePosition - transform.position) * PlayerMovementX.DeterminePlayerDirection();
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            // Update the Z-rotation of the light sprite to match the angle
            if (angle is < ANGLE_THRESHOLD and > -ANGLE_THRESHOLD)
                transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}