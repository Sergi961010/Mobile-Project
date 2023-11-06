using TheCreators.Managers;
using UnityEngine;

namespace TheCreators.CoreSystem.CoreComponents.StateMachine
{
    [CreateAssetMenu(fileName = "FlyState", menuName = "PlayerStates/Fly")]
    public class Fly : PlayerState
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
        private readonly Stamina _stamina;
        private Stamina Stamina
        {
            get => _stamina != null ? _stamina : _context.GetCoreComponent<Stamina>();
        }
        private readonly StateMachineComponent _stateMachine;
        private StateMachineComponent StateMachine
        {
            get => _stateMachine != null ? _stateMachine : _context.GetCoreComponent<StateMachineComponent>();
        }
        public float defaultForce = 20f;
        public float smoothFactor = .2f;
        public float staminaCost = 20f;
        public override void Enter()
        {
            Movement.ModifyGravity(smoothFactor);
            Movement.ModifyYVelocity(smoothFactor);
            PlayerAnimator.PlayAnimation(animations[0]);
            SoundManager.Instance.PlayAudioEvent(audioEvent);
            Stamina.CanRegenerate = false;
        }
        public override void LogicUpdate()
        {
            PlayerAnimator.PlayAnimation(animations[1]);
            Stamina.SubstractStamina(staminaCost);
            if (!InputController.IsFlying || Stamina.CurrentStamina == 0)
                TransitionToInAir();
        }
        public override void PhysicsUpdate()
        {
            Movement.Fly(defaultForce);
        }
        public override void Exit()
        {
            PlayerAnimator.PlayAnimation(animations[2]);
            Movement.ResetGravityScale();
        }
        private void TransitionToInAir()
        {
            StateMachine.StateMachine.SwitchState(StateMachine.inAirState);
        }
    }
}