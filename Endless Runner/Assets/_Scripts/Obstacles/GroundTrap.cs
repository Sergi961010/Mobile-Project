using System;
using TheCreators.CustomEventSystem;
using UnityEngine;

namespace TheCreators.Obstacles
{
    public class GroundTrap : MonoBehaviour
    {
        private Animator _animator;
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        private void OnEnable()
        {
            GameEvent.OnPlayerDeath.AddListener(ChangeAnimation);
        }

        private void ChangeAnimation()
        {
            _animator.SetTrigger("Collision");
        }
    }
}
