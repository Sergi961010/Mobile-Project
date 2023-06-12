using TheCreators.CustomEventSystem;
using TheCreators.ScriptableObjects;
using UnityEngine;

namespace TheCreators.Player.Abilities
{
    public class Jump : MonoBehaviour
    {
        [SerializeField] private JumpData _jumpData;
        private CollisionSenses _collisionSenses;
        [SerializeField] private PlayerInputManager _inputManager;
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _collisionSenses = GetComponentInChildren<CollisionSenses>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        private void Start()
        {
            _rigidbody.gravityScale = _jumpData.gravityScale;
        }
        private void OnEnable()
        {
            GameEvent.OnPerformJump.AddListener(OnJumpInput);
        }
        private void Update()
        {
            
        }
        private void FixedUpdate()
        {
            if (_collisionSenses.Grounded)
                _rigidbody.gravityScale = _jumpData.gravityScale;
            else if (Mathf.Abs(_rigidbody.velocity.y) < _jumpData.jumpHangTimeThreshold)
                _rigidbody.gravityScale = _jumpData.gravityScale * _jumpData.jumpHangGravityMultiplier;
            else if (_rigidbody.velocity.y < 0)
                _rigidbody.gravityScale = _jumpData.gravityScale * _jumpData.fallGravityMultiplier;
        }
        public void OnJumpInput()
        {
            if (_collisionSenses.Grounded)
            {
                _rigidbody.AddForce(Vector2.up * _jumpData.jumpForce, ForceMode2D.Impulse);
                _inputManager.JumpBufferCounter = 0f;
            }
        }
    }
}
