using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace TheCreators.Input
{
    [CreateAssetMenu]
    public class InputReader : ScriptableObject, GameInput.IGameplayActions
    {
        public GameInput GameInput { get; private set; }
        public event UnityAction Jump = delegate { };
        public event UnityAction<bool> Fly = delegate { };
        public event UnityAction Burrow = delegate { };
        public event UnityAction Unburrow = delegate { };

        private readonly float minimumDistance = 100f;
        private readonly float directionThreshold = .9f;

        private Vector2 touchStartPosition, touchEndPosition;
        private void OnEnable()
        {
            if (GameInput == null)
            {
                GameInput = new();
                GameInput.Gameplay.SetCallbacks(this);
            }
        }
        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Started)
            {
                if (!EventSystem.current.IsPointerOverGameObject())
                    Jump.Invoke();
            }
        }
        public void OnFly(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Performed:
                    Fly.Invoke(true);
                    break;
                case InputActionPhase.Canceled:
                    Fly.Invoke(false);
                    break;
            }
        }
        public void OnPrimaryTouch(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Started:
                    touchStartPosition = context.ReadValue<Vector2>();
                    break;
                case InputActionPhase.Performed:
                    touchEndPosition = context.ReadValue<Vector2>();
                    break;
                case InputActionPhase.Canceled:
                    DetectSwipe(touchStartPosition, touchEndPosition);
                    break;
            }
        }

        public void OnBurrow(InputAction.CallbackContext context)
        {
            if (context.phase != InputActionPhase.Started) return;
            if (!EventSystem.current.IsPointerOverGameObject())
                Burrow.Invoke();
        }

        public void OnUnburrow(InputAction.CallbackContext context)
        {
            if (context.phase != InputActionPhase.Started) return;
            if (!EventSystem.current.IsPointerOverGameObject())
                Unburrow.Invoke();
        }

        private void DetectSwipe(Vector2 startPosition, Vector2 endPosition)
        {
            if (Vector2.Distance(startPosition, endPosition) >= minimumDistance)
            {
                Vector2 direction = endPosition - startPosition;
                SwipeDirection(direction.normalized);
            }
        }
        private void SwipeDirection(Vector2 direction)
        {
            if (Vector2.Dot(Vector2.down, direction) > directionThreshold)
            {
                Burrow.Invoke();
            }
            if (Vector2.Dot(Vector2.up, direction) > directionThreshold)
            {
                Unburrow.Invoke();
            }
        }
    }
}