using TheCreators.CustomEventSystem;
using UnityEngine;

namespace TheCreators.Player
{
    public class CollisionSenses : MonoBehaviour
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
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Obstacle"))
                Debug.Log("Kill player");
                GameEvent.OnPlayerDeath.Invoke();
        }
    }
}