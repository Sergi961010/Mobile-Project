using TheCreators.Managers;
using UnityEngine;

namespace TheCreators.CoreSystem.CoreComponents.StateMachine
{
    [CreateAssetMenu(fileName = "DigEnterState", menuName = "PlayerStates/Dig/DigEnter")]
    public class DigEnter : PlayerState
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
        public float startYPosition = -2f;
        public float endYPosition = -3.4f;
        private float _stateDuration;
        public override void Enter()
        {
            _stateDuration = animations[0].length;
            Movement.Rigidbody.isKinematic = true;
            Movement.Rigidbody.useFullKinematicContacts = true;
            PlayerAnimator.PlayAnimation(animations[0]);
            SpriteRendererComponent.ChangeSortingOrder(2);
            SoundManager.Instance.PlayAudioEvent(audioEvent);
            Stamina.CanRegenerate = false;
        }
        public override void Exit()
        {
            
        }
        public override void LogicUpdate()
        {
            _stateDuration -= Time.deltaTime;
            if (_stateDuration <= 0)
                TransitionToDigLoop();
        }
        public override void PhysicsUpdate()
        {
            Movement.HandleDigTranslation(endYPosition);
        }
        private void TransitionToDigLoop()
        {
            StateMachine.StateMachine.SwitchState(StateMachine.digLoopState);
        }
    }
}
