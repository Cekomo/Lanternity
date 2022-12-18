using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLightMovement : MonoBehaviour
{
    [SerializeField] private GameObject torch;
    private Vector2[] torchLocations;
    
    void Start()
    {
        torchLocations[8] = new Vector2();
        
    }

    
    public void Update()
    {
        if (PlayerMovement.pMovementVector2.x > 0.1f)
        {
            RunWithTorch();
        }
    }

    private void RunWithTorch()
    {
        
    }
}
