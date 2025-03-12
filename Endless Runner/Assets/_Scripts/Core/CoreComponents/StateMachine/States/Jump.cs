using TheCreators.CoreSystem.CoreComponents;
using TheCreators.Managers;
using UnityEngine;

namespace TheCreators.Player.StateMachine.States
{
    [CreateAssetMenu(fileName = "JumpState", menuName = "PlayerStates/Jump")]
    public class Jump : PlayerState
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
        private readonly InputController _inputController;
        private InputController InputController
        {
            get => _inputController != null ? _inputController : _context.GetCoreComponent<InputController>();
        }
        private readonly StateMachineComponent _stateMachine;
        private StateMachineComponent StateMachine
        {
            get => _stateMachine != null ? _stateMachine : _context.GetCoreComponent<StateMachineComponent>();
        }
        
        public float jumpHeight = 2f;
        public float jumpTimeToApex = .5f;
        public float jumpHangTimeThreshold = .1f;
        public float jumpHangGravityMultiplier = .5f;
        public float transitionToFlyThreshold = .5f;
        public override void Enter()
        {
            Movement.Jump(jumpHeight, jumpTimeToApex);
            PlayerAnimator.PlayAnimation(animations[0]);
            SoundManager.Instance.PlayAudioEvent(audioEvent);
        }
        public override void LogicUpdate()
        {
            if (InputController.IsFlying) TransitionToFly();

            if (Movement.Rigidbody.velocity.y < -jumpHangTimeThreshold) TransitionToInAir();
        }
        public override void PhysicsUpdate()
        {
        }
        public override void Exit()
        {
        }
        private void TransitionToFly()
        {
            if(Movement.Rigidbody.position.y >= -transitionToFlyThreshold)
                StateMachine.StateMachine.SwitchState(StateMachine.flyState);
        }
        private void TransitionToInAir()
        {
            StateMachine.StateMachine.SwitchState(StateMachine.inAirState);
        }
    }
}
