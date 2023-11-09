using UnityEngine;

namespace TheCreators.CustomEventSystem
{
    public static class GameEventBus
    {
        #region Input
        public static readonly CustomEvent OnPerformJump = new();
        public static readonly CustomEvent OnPerformFly = new();
        public static readonly CustomEvent OnCancelFly = new();
        public static readonly CustomEvent OnPerformBurrow = new();
        public static readonly CustomEvent OnPerformUnburrow = new();
        public static readonly CustomEvent<float> OnPerformStaminaAbility = new();
        public static readonly CustomEvent<float> OnCancelStaminaAbility = new();
        public static readonly CustomEvent<Vector2, float> StartTouch = new();
        public static readonly CustomEvent<Vector2, float> EndTouch = new();
        #endregion
        public static readonly CustomEvent OnGroundCollision = new();

        public static readonly CustomEvent<GameObject> OnPlatformSpawn = new();

        public static readonly CustomEvent OnScreenObstacleTrigger = new();
        public static readonly CustomEvent OnAlertFinished = new();

        public static readonly CustomEvent OnPlayerDeath = new();
        public static readonly CustomEvent OnPlayerRevive = new();

        public static readonly CustomEvent<float, float> OnStaminaBarUpdate = new();
    }
}