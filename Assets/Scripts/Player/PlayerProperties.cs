using UnityEngine;

public class PlayerProperties : MonoBehaviour
{        
    public static Rigidbody2D rbPlayer;

    public Animator PlayerAnimator;
    public LayerMask PlatformsLayerMask;
    
    [HideInInspector] public CapsuleCollider2D CapsuleCollider;

    public void Start()
    {
        CapsuleCollider = GetComponent<CapsuleCollider2D>();
        rbPlayer = GetComponent<Rigidbody2D>();
    }

    protected Vector2 GetPlayerVelocity()
    {
        return rbPlayer.velocity;
    }

    public static bool CheckIfPlayerMoving()
    {
        return rbPlayer.velocity.magnitude > 0;
    }
}
