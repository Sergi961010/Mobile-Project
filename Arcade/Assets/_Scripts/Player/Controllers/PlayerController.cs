using UnityEngine;
using TheCreators.CustomEventSystem;
using TheCreators.ScriptableObjects;

namespace TheCreators.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerData _playerData;
        private Rigidbody2D _rigidbody;
        private bool isGrounded;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            isGrounded = true;
            SetGravityScale(_playerData.defaultGravityModifier);
        }

        private void OnEnable()
        {
            GameEvent.OnPerformJump.AddListener(Jump);
            GameEvent.OnGroundCollision.AddListener(OnGroundCollision);
        }

        private void OnDisable()
        {
            GameEvent.OnPerformJump.RemoveListener(Jump);
            GameEvent.OnGroundCollision.RemoveListener(OnGroundCollision);
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Jump()
        {
            if (isGrounded)
            {
                _rigidbody.AddForce(Vector2.up * _playerData.jumpForce, ForceMode2D.Impulse); 
                isGrounded = false;
            }
        }

        private void OnReleasePress()
        {
            if (!isGrounded) SetGravityScale(_playerData.jumpCutGravityModifier);
        }

        private void OnGroundCollision()
        {
            SetGravityScale(_playerData.defaultGravityModifier);
            isGrounded = true;
        }

        private void SetGravityScale(float value)
        {
            _rigidbody.gravityScale = value;
        }

        private void Move()
        {
            _rigidbody.velocity = new Vector2(5, _rigidbody.velocity.y);
        }
    }
}
