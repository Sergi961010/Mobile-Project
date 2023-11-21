using TheCreators.Interfaces;
using UnityEngine;
using UnityEngine.Events;

namespace TheCreators.Obstacles
{
    [RequireComponent(typeof(Collider2D))]
    public class CollisionController : MonoBehaviour
    {
        private Animator _animator;
        public UnityEvent OnPlayerCollisionWithObstacle;
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            IDamageable damageable = collision.gameObject.GetComponentInChildren<IDamageable>();
            if (damageable != null)
            {
                damageable.Damage();
                _animator.SetTrigger("Collision");
                OnPlayerCollisionWithObstacle.Invoke();
            }
        }
    }
}