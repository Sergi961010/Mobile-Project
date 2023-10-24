using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace TheCreators.Input
{
    [CreateAssetMenu]
    public class InputReader : ScriptableObject, GameInput.IGameplayActions
    {
        private GameInput _gameInput;
        public event UnityAction Jump = delegate { };
        public event UnityAction<bool> Fly = delegate { };
        public event UnityAction<bool> Dig = delegate { };

        public float minimumDistance = .2f;
        public float maximumTime = 1f;
        public float directionThreshold = .9f;

        private Vector2 touchStartPosition, touchEndPosition;
        private void OnEnable()
        {
            if (_gameInput == null)
            {
                _gameInput = new();
                _gameInput.Gameplay.SetCallbacks(this);
                _gameInput.Gameplay.Enable();
            }
        }
        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Started) Jump.Invoke();
        }

        public void OnFly(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Started:
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
                Dig.Invoke(true);
            }
            if (Vector2.Dot(Vector2.up, direction) > directionThreshold)
            {
                Dig.Invoke(false);
            }
        }
    }
}