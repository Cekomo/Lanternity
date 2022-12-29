using System.Collections;
using System.Collections.Generic;
using Lantern;
using UnityEngine;

public class PlayerHandController : MonoBehaviour
{
    [SerializeField] private GameObject torch;
    [SerializeField] private GameObject lantern;
    [SerializeField] private Animator lightItemAnimator;

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
            lightItemAnimator.SetBool("isTorchOrLanternPicked", true);
        }
        else
        {
            lantern.SetActive(false);
            torch.SetActive(true);
            isTorchOrLanternPicked = true;
            lightItemAnimator.SetBool("isTorchOrLanternPicked", false);
        }
    }
}
