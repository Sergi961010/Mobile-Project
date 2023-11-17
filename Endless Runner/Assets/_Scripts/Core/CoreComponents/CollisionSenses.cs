using UnityEngine;

namespace TheCreators.CoreSystem.CoreComponents
{
    public class CollisionSenses : BaseCoreComponent
    {
        private readonly Death _death;
        private Death Death
        {
            get => _death != null ? _death : Core.GetCoreComponent<Death>();
        }
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
            Collider2D collider = collision.GetContact(0).collider;
            if (collider.gameObject.CompareTag("Obstacle"))
            {
                StartCoroutine(Death.Die());
            }
        }
    }
}