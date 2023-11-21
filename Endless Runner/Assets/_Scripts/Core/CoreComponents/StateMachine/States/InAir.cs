using UnityEngine;

namespace TheCreators.CoreSystem.CoreComponents.StateMachine
{
    [CreateAssetMenu(fileName = "InAirState", menuName = "PlayerStates/InAir")]
    public class InAir : PlayerState
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
        private readonly CollisionSenses _collisionSenses;
        private CollisionSenses CollisionSenses
        {
            get => _collisionSenses != null ? _collisionSenses : _context.GetCoreComponent<CollisionSenses>();
        }
        private readonly InputController _inputController;
        private InputController InputController
        {
            get => _inputController != null ? _inputController : _context.GetCoreComponent<InputController>();
        }
        private readonly StaminaComponent _stamina;
        private StaminaComponent Stamina
        {
            get => _stamina != null ? _stamina : _context.GetCoreComponent<StaminaComponent>();
        }
        private readonly StateMachineComponent _stateMachine;
        private StateMachineComponent StateMachine
        {
            get => _stateMachine != null ? _stateMachine : _context.GetCoreComponent<StateMachineComponent>();
        }
        public float fallGravityMultiplier = 3f;
        public float flyTransitionStaminaTreshold = 20f;
        public override void Enter()
        {
            PlayerAnimator.PlayAnimation(animations[0]);
            Movement.ModifyGravity(fallGravityMultiplier);
        }
        public override void Exit()
        {
            Stamina.CanRegenerate = true;
        }
        public override void LogicUpdate()
        {
            if (CollisionSenses.Grounded) TransitionToLand();
            if (InputController.IsFlying && Stamina.CurrentStamina >= flyTransitionStaminaTreshold)
                TransitionToFly();
        }
        private void TransitionToLand()
        {
            StateMachine.StateMachine.SwitchState(StateMachine.landState);
        }
        private void TransitionToFly()
        {
            StateMachine.StateMachine.SwitchState(StateMachine.flyState);
        }
    }
}