using UnityEngine;

public class PlayerProperties : MonoBehaviour
{    
    public static Rigidbody2D rbPlayer; // check if static use causing any problem
    
    public Animator PlayerAnimator;
    public LayerMask PlatformsLayerMask;
    
    [HideInInspector] public CapsuleCollider2D CapsuleCollider;

    public void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        CapsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    public static bool CheckIfPlayerMoving()
    {
        return rbPlayer.velocity.magnitude > 0;
    }
}
