using System.Collections;
using System.Collections.Generic;
using Lantern;
using UnityEngine;

public class PlayerHandController : MonoBehaviour
{
    [SerializeField] private GameObject torch;
    [SerializeField] private GameObject lantern;

    private bool isTorchOrLanternPicked; 
    
    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Q) || !PickableLanternController.IsLanternPicked()) return;
        
        SwitchBetweenLights();
    }

    private void SwitchBetweenLights()
    {
        if (isTorchOrLanternPicked)
        {
            torch.SetActive(false);
            lantern.SetActive(true);
            isTorchOrLanternPicked = false;
        }
        else
        {
            lantern.SetActive(false);
            torch.SetActive(true);
            isTorchOrLanternPicked = true;
        }
    }
}
