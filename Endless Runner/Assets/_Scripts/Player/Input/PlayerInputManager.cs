using TheCreators.CustomEventSystem;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace TheCreators.Player
{
    public class PlayerInputManager : MonoBehaviour
    {
        private PlayerControls _playerControls;

        private InputAction _jumpAction;
        private InputAction _flyAction;
        private InputAction _primaryTouch;

        private Vector2 _lastPrimaryTouchPosition;

        public bool JumpPressed { get; private set; }

        private void Awake()
        {
            _playerControls = new PlayerControls();

            _jumpAction = _playerControls.Mobile.Jump;
            _flyAction = _playerControls.Mobile.Fly;
            _primaryTouch = _playerControls.Mobile.PrimaryTouch;
        }
        private void OnEnable()
        {
            _playerControls.Enable();
            _jumpAction.started += OnJumpInput;
            _jumpAction.canceled += OnJumpInput;
            _flyAction.performed += OnFlyAction;
            _flyAction.canceled += OnCancelFlyAction;
            _primaryTouch.started += StartPrimaryTouch;
            _primaryTouch.performed += ctx => _lastPrimaryTouchPosition = ctx.ReadValue<Vector2>();
            _primaryTouch.canceled += EndPrimaryTouch;
        }
        private void OnDisable()
        {
            _playerControls.Disable();
            _jumpAction.performed -= OnJumpInput;
            _flyAction.performed -= OnFlyAction;
            _flyAction.canceled -= OnCancelFlyAction;
            _primaryTouch.started -= StartPrimaryTouch;
            _primaryTouch.canceled -= EndPrimaryTouch;
        }
        private void OnCancelFlyAction(InputAction.CallbackContext context)
        {
            GameEvent.OnCancelFly.Invoke();
        }
        private void OnJumpInput(InputAction.CallbackContext context)
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                JumpPressed = context.ReadValueAsButton();
            }
        }
        public void UseJumpInput() => JumpPressed = false;
        private void OnFlyAction(InputAction.CallbackContext context)
        {
            GameEvent.OnPerformFly.Invoke();
        }
        private void StartPrimaryTouch(InputAction.CallbackContext context)
        {
            Vector2 screenPosition = _primaryTouch.ReadValue<Vector2>();
            float startTime = (float)context.startTime;
            GameEvent.StartTouch.Invoke(screenPosition, startTime);

        }
        private void EndPrimaryTouch(InputAction.CallbackContext context)
        {
            float startTime = (float)context.startTime;
            GameEvent.EndTouch.Invoke(_lastPrimaryTouchPosition, startTime);

        }
    }
}