using System.Collections;
using System.Collections.Generic;
using Lantern;
using UnityEngine;

public class PlayerHandController : MonoBehaviour
{
    void Update()
    {
        if (PickableLanternController.IsLanternPicked()) // fix this
        {
            transform.GetChild(2).gameObject.SetActive(true);
        }
    }
}
