using UnityEngine;

namespace TheCreators.EventSystem
{
    public static class GameEvent
    {
        public static readonly CustomEvent OnPress = new();
        public static readonly CustomEvent OnReleasePress = new();
        public static readonly CustomEvent OnGroundCollision = new();

        public static readonly CustomEvent OnPlatformSpawn = new();
        public static readonly CustomEvent OnPlatformFall = new();
    }
}