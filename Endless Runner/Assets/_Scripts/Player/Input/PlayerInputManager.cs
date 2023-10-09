using TheCreators.CustomEventSystem;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace TheCreators.Player.Input
{
    public class PlayerInputManager : MonoBehaviour
    {
        private PlayerControls _playerControls;

        public InputAction JumpAction { get; private set; }
        public InputAction FlyAction { get; private set; }
        public InputAction PrimaryTouch { get; private set; }

        private Vector2 _lastPrimaryTouchPosition;
        public SwipeDetection SwipeDetection { get; private set; }
        public bool JumpPerformed { get; private set; }
        public bool FlyPerformed { get; private set; }
        private void Awake()
        {
            SwipeDetection = GetComponent<SwipeDetection>();

            _playerControls = new PlayerControls();

            JumpAction = _playerControls.Mobile.Jump;
            FlyAction = _playerControls.Mobile.Fly;
            PrimaryTouch = _playerControls.Mobile.PrimaryTouch;
        }
        private void OnEnable()
        {
            _playerControls.Enable();
            JumpAction.performed += OnJumpInput;
            FlyAction.performed += OnFlyAction;
            FlyAction.canceled += OnCancelFlyAction;
            PrimaryTouch.started += StartPrimaryTouch;
            PrimaryTouch.performed += ctx => _lastPrimaryTouchPosition = ctx.ReadValue<Vector2>();
            PrimaryTouch.canceled += EndPrimaryTouch;
        }
        private void OnDisable()
        {
            _playerControls.Disable();
            JumpAction.performed -= OnJumpInput;
            FlyAction.performed -= OnFlyAction;
            FlyAction.canceled -= OnCancelFlyAction;
            PrimaryTouch.started -= StartPrimaryTouch;
            PrimaryTouch.canceled -= EndPrimaryTouch;
        }
        private void OnJumpInput(InputAction.CallbackContext context)
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                JumpPerformed = true;
            }
        }
        public void UseJumpInput() => JumpPerformed = false;
        private void OnFlyAction(InputAction.CallbackContext context) => FlyPerformed = true;
        private void OnCancelFlyAction(InputAction.CallbackContext context) => FlyPerformed = false;
        private void StartPrimaryTouch(InputAction.CallbackContext context)
        {
            Vector2 screenPosition = PrimaryTouch.ReadValue<Vector2>();
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