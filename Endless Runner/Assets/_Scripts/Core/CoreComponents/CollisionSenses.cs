using TheCreators.CustomEventSystem;
using UnityEngine;

namespace TheCreators.CoreSystem.CoreComponents
{
    public class CollisionSenses : BaseCoreComponent
    {
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private float _groundCheckRadius;
        [SerializeField] private LayerMask _groundLayer;
        public bool Grounded
        {
            get => Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);
        }
        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(_groundCheck.position, _groundCheckRadius);
        }
        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.CompareTag("Obstacle"))
                StartCoroutine(Core.Death.Die());
        }
    }
}