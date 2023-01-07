using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperties : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rbPlayer;
    
    public Animator PlayerAnimator;
    public LayerMask PlatformsLayerMask;
    
    [HideInInspector] public CapsuleCollider2D CapsuleCollider;

    public void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        CapsuleCollider = GetComponent<CapsuleCollider2D>();
    }
}
