using System;
using UnityEngine;

namespace TheCreators.Player
{
    public class PlayerAnimationController : MonoBehaviour
    {
        private Animator _animator;
        public static event Action OnAnimationFinish;
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        public void AnimationFinished()
        {
            OnAnimationFinish?.Invoke();
        }
        public void PlayAnimation(string name)
        {
            _animator.Play(name);
        }
    }
}
