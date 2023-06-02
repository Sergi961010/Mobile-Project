using System;
using TheCreators.CustomEventSystem;
using UnityEngine;

namespace TheCreators
{
    public class Fly : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private bool _isFlying = false;
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        private void OnEnable()
        {
            GameEvent.OnPerformFly.AddListener(EnableFlyAction);
            GameEvent.OnCancelFly.AddListener(DisableFlyAction);
        }
        private void Update()
        {
            if (_isFlying)
                Move();
        }
        private void Move()
        {
            _rigidbody.velocity = new Vector2(0, 2);
        }
        private void EnableFlyAction()
        {
            _isFlying = true;
        }
        private void DisableFlyAction()
        {
            _isFlying = false;
        }
    }
}
