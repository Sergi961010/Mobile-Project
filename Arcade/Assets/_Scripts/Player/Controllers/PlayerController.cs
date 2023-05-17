using UnityEngine;
using TheCreators.EventSystem;
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
            SetGravityScale(_playerData.defaultGravity);
        }

        private void OnEnable()
        {
            GameEvent.onPress.AddListener(OnPress);
            GameEvent.onReleasePress.AddListener(OnReleasePress);
            GameEvent.onGroundCollision.AddListener(OnGroundCollision);
        }

        private void OnDisable()
        {
            GameEvent.onPress.RemoveListener(OnPress);
            GameEvent.onReleasePress.RemoveListener(OnReleasePress);
            GameEvent.onGroundCollision.RemoveListener(OnGroundCollision);
        }

        private void OnPress()
        {
            if (isGrounded)
            {
                _rigidbody.AddForce(Vector2.up * _playerData.JumpForce, ForceMode2D.Impulse); 
                isGrounded = false;
            }
        }

        private void OnReleasePress()
        {
            if (!isGrounded) SetGravityScale(_playerData.jumpCutGravity);
        }

        private void OnGroundCollision()
        {
            SetGravityScale(_playerData.defaultGravity);
            isGrounded = true;
        }

        private void SetGravityScale(float value)
        {
            _rigidbody.gravityScale = value;
        }
    }
}
