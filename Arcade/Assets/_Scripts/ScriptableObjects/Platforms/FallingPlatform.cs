using UnityEngine;

namespace TheCreators.ScriptableObjects.Platforms
{
    [CreateAssetMenu(fileName = "NewFallingPlatform", menuName = "Platform/FallingPlatform")]
    public class FallingPlatform : Platform
    {
        public float fallSpeed = 0;
        public float minDelay = 0;
        public float maxDelay = 0;
    }
}
