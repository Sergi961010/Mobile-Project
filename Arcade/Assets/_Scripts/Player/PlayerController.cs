using UnityEngine;
using TheCreators.EventSystem;

namespace TheCreators.Player
{
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        [SerializeField] private float _jumpForce;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            GameEvent.onPlayerJump.AddListener(Jump);
        }

        private void Jump()
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce);
        }
    }
}
