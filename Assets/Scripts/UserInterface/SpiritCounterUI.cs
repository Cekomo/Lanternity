using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UserInterface
{
    public class SpiritCounterUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI  textMeshProUGUI;
        
        private void Start()
        {
            textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        }
        
        public void SetSpiritCaptured(int spiritAmount)
        {
            textMeshProUGUI.text = "<sprite name=\"S" + spiritAmount + "\">";
        }
    }

}