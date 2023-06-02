using System;
using TheCreators.CustomEventSystem;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace TheCreators.Player
{
    public class PlayerInputManager : MonoBehaviour
    {
        private PlayerInput _playerInput;

        private InputAction _jumpAction;
        private InputAction _flyAction;

        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
            _jumpAction = _playerInput.actions.FindAction("Jump");
            _flyAction = _playerInput.actions.FindAction("Fly");
        }

        private void OnEnable()
        {
            _jumpAction.performed += OnJumpAction;
            _flyAction.performed += OnFlyAction;
            _flyAction.canceled += OnCancelFlyAction;
        }

        private void OnDisable()
        {
            _jumpAction.performed -= OnJumpAction;
            _flyAction.performed -= OnFlyAction;
            _flyAction.canceled -= OnCancelFlyAction;
        }

        private void OnCancelFlyAction(InputAction.CallbackContext context)
        {
            GameEvent.OnCancelFly.Invoke();
        }

        private void OnJumpAction(InputAction.CallbackContext context)
        {
            //if (!EventSystem.current.IsPointerOverGameObject())
                GameEvent.OnPerformJump.Invoke();
        }

        private void OnFlyAction(InputAction.CallbackContext context)
        {
            GameEvent.OnPerformFly.Invoke();
        }
    }
}