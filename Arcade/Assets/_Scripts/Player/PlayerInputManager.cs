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

        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
            _pressAction = _playerInput.actions.FindAction("Press");
        }

        private void OnEnable()
        {
            _pressAction.performed += OnPress;
        }

        private void OnDisable()
        {
            _pressAction.performed -= OnPress;
        }

        private void OnPress(InputAction.CallbackContext context)
        {
            GameEvent.onPlayerJump.Invoke();
        }

    }

}