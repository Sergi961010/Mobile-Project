using System.Collections;
using TheCreators.Interfaces;
using TheCreators.Managers;
using TheCreators.Scripts.ScriptableObjects.Audio;
using UnityEngine;
using UnityEngine.Events;

namespace TheCreators.CoreSystem.CoreComponents
{
    public class Death : BaseCoreComponent, IDamageable
    {
        private readonly PlayerAnimator _playerAnimator;
        private PlayerAnimator PlayerAnimator
        {
            get => _playerAnimator != null ? _playerAnimator : Core.GetCoreComponent<PlayerAnimator>();
        }
        private readonly Movement _movement;
        private Movement Movement
        {
            get => _movement != null ? _movement : Core.GetCoreComponent<Movement>();
        }
        private readonly InputController _inputController;
        private InputController InputController
        {
            get => _inputController != null ? _inputController : Core.GetCoreComponent<InputController>();
        }
        private readonly SpriteRendererComponent _spriteRendererComponent;
        private SpriteRendererComponent SpriteRendererComponent
        {
            get => _spriteRendererComponent != null ? _spriteRendererComponent : Core.GetCoreComponent<SpriteRendererComponent>();
        }
        private readonly StateMachineComponent _stateMachine;
        private StateMachineComponent StateMachine
        {
            get => _stateMachine != null ? _stateMachine : Core.GetCoreComponent<StateMachineComponent>();
        }
        [SerializeField] private AnimationClip _animationClip;
        public UnityEvent DeathEvent;
        public AudioEvent audioEvent;
        public IEnumerator Die()
        {
            PlayerAnimator.PlayAnimation(_animationClip);
            SoundManager.Instance.PlayAudioEvent(audioEvent);
            StateMachine.gameObject.SetActive(false);
            yield return new WaitForSeconds(_animationClip.length);
            Core.transform.parent.gameObject.SetActive(false);
            DeathEvent.Invoke();
        }
        public void Damage()
        {
            StartCoroutine(Die());
        }
    }
}