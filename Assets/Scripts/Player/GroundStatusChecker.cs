using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class GroundStatusChecker : PlayerProperties
    {
        private static readonly int IsGrounded = Animator.StringToHash("isGrounded");
        
        public bool CheckIfGrounded()
        {
            var bCBounds = CapsuleCollider.bounds;
            RaycastHit2D raycastHit2D = Physics2D.BoxCast(bCBounds.center, bCBounds.size,
                0f, Vector2.down, 0.1f, PlatformsLayerMask);
            return !ReferenceEquals(raycastHit2D.collider, null); // changed from raycastHit2D.collider != null;
        }
    }
}
