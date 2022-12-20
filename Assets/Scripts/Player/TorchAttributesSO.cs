using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "LightAttributeSO", menuName = "ScriptableObjects/PlayerScriptableObject", order = 1)]
    public class TorchAttributesSO : ScriptableObject
    {
        // this are the coordinates of torch during running and jumping
        // no need for now
        
        public static readonly Vector2 TorchCoordinateOnIdle = new(0.1f, -0.02f);
        public static readonly Vector2[] TorchCoordinatesOnRunning =
        {
            new(-0.04f,-0.09f), new(0.1f, -0.01f), new(0.14f, 0), new(0, 0.09f),
            new(0.07f, 0.07f), new(0.12f, -0.08f), new(-0.02f, -0.08f), new(-0.05f, -0.1f)
        };

        public static readonly Vector2[] TorchCoordinatesOnTakingOff =
        {
            new(0.1f, 0), new(0.11f, 0.02f), new(0.1f, -0.03f), 
            new(0.1f, -0.02f), new(0.09f, -0.07f)
        };

        public static readonly Vector2[] TorchCoordinatesOnJumping =
        {
            new(0.09f, 0.09f), new(0.15f, 0.17f), new(0.21f, 0.28f)
        };

        public static readonly Vector2[] TorchCoordinatesOnLanding =
        {
            new(0.17f, 0.19f), new(0.16f, 0), new(0.11f, -0.1f), new(0.11f, -0.02f),
            new(0.12f, -0.13f), new(0.11f, -0.1f), new(0.1f, -0.1f)
        };
    }
}