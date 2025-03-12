using System.Collections;
using UnityEngine;

namespace TheCreators.CoreSystem.CoreComponents
{
    public class PlayerAnimator : CoreComponent
    {
        private Animator _animator;
        private bool isLocked = false;
        protected override void Awake()
        {
            base.Awake();
            _animator = GetComponentInParent<Animator>();
        }
        public void PlayAnimation(AnimationClip animationClip)
        {
            if (isLocked) return;
            _animator.CrossFade(animationClip.name, 0, 0);
        }
        public void PlayLockedAnimation(AnimationClip animationClip)
        {
            isLocked = true;
            StartCoroutine(CoroutinePlayAnimation(animationClip));
        }
        private IEnumerator CoroutinePlayAnimation(AnimationClip animationClip)
        {
            _animator.CrossFade(animationClip.name, 0, 0);
            yield return new WaitForSeconds(animationClip.length);
            isLocked = false;
        }
    }
}
