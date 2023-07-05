using UnityEngine;

namespace TheCreators.CustomEventSystem
{
    public static class GameEvent
    {
        public static readonly CustomEvent OnPerformJump = new();
        public static readonly CustomEvent OnPerformFly = new();
        public static readonly CustomEvent OnCancelFly = new();
        public static readonly CustomEvent Dig = new();
        public static readonly CustomEvent<Vector2, float> StartTouch = new();
        public static readonly CustomEvent<Vector2, float> EndTouch = new();

        public static readonly CustomEvent OnGroundCollision = new();

        public static readonly CustomEvent OnPlatformSpawn = new();

        public static readonly CustomEvent OnScreenObstacleTrigger = new();
        public static readonly CustomEvent OnAlertFinished = new();

        public static readonly CustomEvent OnPlayerDeath = new();
        public static readonly CustomEvent OnPlayerRevive = new();
    }
}