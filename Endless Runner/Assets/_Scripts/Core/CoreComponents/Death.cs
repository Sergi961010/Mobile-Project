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
            Core.InputController.DisableInput();
            Core.StateMachine.gameObject.SetActive(false);
            Core.Movement.Rigidbody.isKinematic = true;
            Core.Movement.gameObject.SetActive(false);
            Core.PlayerAnimator.PlayAnimation(_animationClip);
            yield return new WaitForSeconds(_animationClip.length);
            Core.SpriteRenderer.gameObject.SetActive(false);
            DeathEvent.Invoke();
        }
    }
}