using TheCreators.ScriptableObjects;
using UnityEngine;

namespace TheCreators.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private RunData _playerData;

        [SerializeField] private CollisionSenses _collisionSenses;
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            _rigidbody.velocity = new Vector2(_playerData.Speed, _rigidbody.velocity.y);
        }
    }
}
