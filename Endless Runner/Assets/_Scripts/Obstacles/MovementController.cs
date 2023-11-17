using UnityEngine;

namespace TheCreators.Obstacles
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class MovementController : MonoBehaviour
	{
		[SerializeField, HideInInspector] private Rigidbody2D _rigidbody2D;
        private void FixedUpdate()
        {
            _rigidbody2D.MovePosition(_rigidbody2D.position + (GameplaySettings.GameSpeed * Time.deltaTime * Vector2.left));
        }
        private void OnValidate()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            if (_rigidbody2D == null) _rigidbody2D = gameObject.AddComponent<Rigidbody2D>();

            _rigidbody2D.isKinematic = true;
            _rigidbody2D.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
            _rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
    }
}