using TheCreators.Managers;
using UnityEngine;

namespace TheCreators.CoreSystem.CoreComponents.StateMachine
{
    [CreateAssetMenu(fileName = "DigExitState", menuName = "PlayerStates/Dig/DigExit")]
    public class DigExit : PlayerState
    {
        private readonly PlayerAnimator _playerAnimator;
        private PlayerAnimator PlayerAnimator
        {
            get => _playerAnimator != null ? _playerAnimator : _context.GetCoreComponent<PlayerAnimator>();
        }
        private readonly Movement _movement;
        private Movement Movement
        {
            get => _movement != null ? _movement : _context.GetCoreComponent<Movement>();
        }
        private readonly StaminaComponent _stamina;
        private StaminaComponent Stamina
        {
            get => _stamina != null ? _stamina : _context.GetCoreComponent<StaminaComponent>();
        }
        private readonly SpriteRendererComponent _spriteRendererComponent;
        private SpriteRendererComponent SpriteRendererComponent
        {
            get => _spriteRendererComponent != null ? _spriteRendererComponent : _context.GetCoreComponent<SpriteRendererComponent>();
        }
        private readonly StateMachineComponent _stateMachine;
        private StateMachineComponent StateMachine
        {
            get => _stateMachine != null ? _stateMachine : _context.GetCoreComponent<StateMachineComponent>();
        }
        public float startYPosition = -3.4f;
        public float endYPosition = -2;
        private float _stateDuration;
        public override void Enter()
        {
            _stateDuration = animations[0].length;
            PlayerAnimator.PlayAnimation(animations[0]);
            SoundManager.Instance.PlayAudioEvent(audioEvent);
        }
        public override void Exit()
        {
            Movement.Rigidbody.isKinematic = false;
            Stamina.CanRegenerate = true;
            SpriteRendererComponent.ChangeSortingOrder(-1);
        }
        public override void LogicUpdate()
        {
            _stateDuration -= Time.deltaTime;
            if (_stateDuration <= 0)
                TransitionToRun();
        }
        public override void PhysicsUpdate()
        {
            Movement.HandleDigTranslation(endYPosition);
        }
        private void TransitionToRun()
        {
            StateMachine.StateMachine.SwitchState(StateMachine.runState);
        }
    }
}
