using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Lantern
{
    public class LanternBeamController : MonoBehaviour
    {
        private void Update()
        {
            var mousePosition = Input.mousePosition;
            // Convert the mouse position from screen space to world space
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            var direction = mousePosition - transform.position;
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            // Update the Z-rotation of the light sprite to match the angle
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        
        // public void FaceTowardsMousePointer()
        // {
        //     mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //
        //     var lightTransform = transform;
        //     playerMousePosDifference =
        //         new Vector2(mousePos.x - lightTransform.position.x, mousePos.y - lightTransform.position.y);
        //     lightTransform.up = playerMousePosDifference;
        // }
    }
}