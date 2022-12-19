using UnityEngine;

[CreateAssetMenu(fileName = "LightAttributeSO", menuName = "ScriptableObjects/PlayerScriptableObject", order = 1)]
public class TorchAttributesSO : ScriptableObject
{
    public static readonly Vector2 torchCoordinateOnIdle = new(0.1f, -0.02f);
    public static readonly Vector2[] torchCoordinatesOnRunning =
    {
        new(-0.04f,-0.09f), new(0.1f, -0.01f), new(0.14f, 0), new(0, 0.09f),
        new(0.07f, 0.07f), new(0.12f, -0.08f), new(-0.03f, -0.08f), new(-0.05f, -0.1f)
    };
}