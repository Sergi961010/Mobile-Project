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
        public bool CanFly
        {
            get => !Physics2D.Raycast(transform.position, Vector2.down, 1f, _groundLayer);
        }
        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(_groundCheck.position, _groundCheckRadius);
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                StartCoroutine(Core.Death.Die());
            }
        }
    }
}