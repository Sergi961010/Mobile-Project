using UnityEngine;

namespace TheCreators.ScriptableObjects.Platforms
{
    [CreateAssetMenu(fileName = "NewFallingPlatform", menuName = "Platform/FallingPlatform")]
    public class FallingPlatform : Platform
    {
        public float fallSpeed;
        public float minDelay;
        public float maxDelay;
    }
}
