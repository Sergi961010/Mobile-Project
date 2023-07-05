using UnityEngine;

namespace TheCreators
{
    public class MoveLeft : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private readonly float _speed = 2f;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        private void Start()
        {
            _rigidbody.velocity = Vector2.left * _speed;
        }
    }
}
