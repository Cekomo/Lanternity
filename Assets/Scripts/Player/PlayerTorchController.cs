using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerTorchController : MonoBehaviour
{
    [SerializeField] private GameObject torch;
    private Light2D torchLight;
    private Vector2[] torchLocations;
    private Vector2 torchDefaultLocation;
    private int locationIndex;
    private float torchTime;

    void Start()
    {
        torchLight = torch.GetComponent<Light2D>();
        
        torchLocations = new Vector2[8];

        torchDefaultLocation = TorchAttributesSO.torchCoordinateOnIdle;
        for (var i = 0; i < 8; i++)
            torchLocations[i] = TorchAttributesSO.torchCoordinatesOnRunning[i];
        
        StartCoroutine(FlickTorch());
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
        // synchronization is mostly fixed but still slight offset exists between light & animation
        // approximately 104 mseconds per frame
        if (torchTime >= 0.104f)
        {
            torch.transform.localPosition = torchLocations[locationIndex];
            locationIndex++;
            torchTime = 0f;
            if (locationIndex == 8) locationIndex = 0;
        }
    }

    IEnumerator FlickTorch()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.15f);
            torchLight.intensity = Random.Range(1.6f, 2f);
        }
    }
}