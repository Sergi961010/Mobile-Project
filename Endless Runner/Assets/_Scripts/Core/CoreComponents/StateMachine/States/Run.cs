using UnityEngine;

namespace TheCreators.CoreSystem.CoreComponents.StateMachine
{
    [CreateAssetMenu(fileName = "RunState", menuName = "PlayerStates/Run")]
    public class Run : PlayerState
    {
        private readonly PlayerAnimator _playerAnimator;
        private PlayerAnimator PlayerAnimator
        {
            get => _playerAnimator != null ? _playerAnimator : _context.GetCoreComponent<PlayerAnimator>();
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
        public float _speed = 6f;
        public float digTransitionStaminaTreshold = 20f;
        public override void Enter()
        {
            PlayerAnimator.PlayAnimation(animations[0]);
        }
        public override void LogicUpdate()
        {
            if (InputController.CanJump) 
                TransitionToJump();
            if (InputController.CanBurrow && Stamina.CurrentStamina >= digTransitionStaminaTreshold)
                TransitionToDig();
        }
        public override void PhysicsUpdate()
        {
        }
        public override void Exit()
        {
        }
        private void TransitionToJump()
        {
            StateMachine.StateMachine.SwitchState(StateMachine.jumpState);
        }
        private void TransitionToDig()
        {
            StateMachine.StateMachine.SwitchState(StateMachine.digEnterState);
        }
    }
}