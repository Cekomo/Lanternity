using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UserInterface
{
    [CreateAssetMenu(fileName = "Numbers", menuName = "ScriptableObjects/Numbers", order = 1)]
    public class NumbersSO : ScriptableObject
    {
        public Sprite[] numbers;
    }


    public enum NumberState
    {
        Zero,
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine
    }
}