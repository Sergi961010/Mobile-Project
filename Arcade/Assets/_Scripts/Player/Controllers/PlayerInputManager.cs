using System;
using TheCreators.EventSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TheCreators.Player
{
    public class PlayerInputManager : MonoBehaviour
    {
        private PlayerInput _playerInput;

        private InputAction _pressAction;

        public bool IsPressHolded { get; private set; }

        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
            _pressAction = _playerInput.actions.FindAction("Press");
            IsPressHolded = false;
        }

        private void OnEnable()
        {
            _pressAction.performed += OnPress;
            _pressAction.canceled += OnReleaseTap;
        }

        private void OnDisable()
        {
            _pressAction.performed -= OnPress;
            _pressAction.canceled -= OnReleaseTap;
        }

        private void OnReleaseTap(InputAction.CallbackContext obj)
        {
            GameEvent.onReleasePress.Invoke();
        }

        private void OnPress(InputAction.CallbackContext context)
        {
            GameEvent.onPress.Invoke();
        }

    }

}