using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLightMovement : MonoBehaviour
{
    [SerializeField] private GameObject torch;
    private Vector2[] torchLocations;
    private Vector2 torchDefaultLocation;
    private int locationIndex;
    private float torchTime;

    void Start()
    {
        torchLocations = new Vector2[8];

        torchDefaultLocation = TorchCoordinatesSO.torchCoordinateDefault;
        for (var i = 0; i < 8; i++)
            torchLocations[i] = TorchCoordinatesSO.torchCoordinatesOnRunning[i];
    }

    
    public void Update()
    {
        torchTime += Time.deltaTime;
        if (Mathf.Abs(PlayerMovement.pMovementVector2.x) > 0.1f)
        {
            RunWithTorch();
        }
        else
        {
            torch.transform.localPosition = torchDefaultLocation;
            locationIndex = 0;
        }
    }

    private void RunWithTorch() // there are synchronization problems between sprite frame and light
    { // convert it to coroutine
        // approximately 104 mseconds per frame
        if (torchTime >= 0.104f)
        {
            torch.transform.localPosition = torchLocations[locationIndex];
            locationIndex++;
            torchTime = 0f;
            if (locationIndex == 8) locationIndex = 0;
        }
    }
}
