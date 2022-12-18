using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlayerScriptableObject", order = 1)]
public class TorchCoordinatesSO : ScriptableObject
{
    private Vector2[] torchCoordinates =
    {
        new(-0.04f,-0.09f), new(0.1f, -0.01f), new(0.14f, 0), new(0, 0.09f),
        new(0.7f, 0.7f), new(0.12f, -0.08f), new(-0.03f, -0.08f), new(-0.05f, -0.1f)
    };
    
    
}
