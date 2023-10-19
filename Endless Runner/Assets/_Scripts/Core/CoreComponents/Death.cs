using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace TheCreators.CoreSystem.CoreComponents
{
    public class Death : BaseCoreComponent
    {
        [SerializeField] private AnimationClip _animationClip;
        public UnityEvent DeathEvent;
        public IEnumerator Die()
        {
            Core.InputManager.DisablePlayerControls();
            //Core.PlayerAnimator.PlayAnimation(_animationClip);
            yield return new WaitForSeconds(1f);
            DeathEvent.Invoke();
        }
    }
}