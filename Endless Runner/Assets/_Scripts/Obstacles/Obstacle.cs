using UnityEngine;

namespace TheCreators.Obstacles
{
    public class Obstacle : MonoBehaviour
    {
        private Animator _animator;
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            _animator.SetTrigger("Collision");
        }
    }
}