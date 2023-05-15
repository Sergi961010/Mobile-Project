using UnityEngine;

namespace TheCreators.EventSystem
{
    public static class GameEvent
    {
        public static readonly CustomEvent onPress = new();
        public static readonly CustomEvent onReleasePress = new();
        public static readonly CustomEvent onGroundCollision = new();

        public static readonly CustomEvent<Vector2> onPlatformSpawn = new();
    }
}