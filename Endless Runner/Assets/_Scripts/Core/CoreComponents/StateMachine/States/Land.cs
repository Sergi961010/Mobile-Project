using UnityEngine;

namespace TheCreators.CoreSystem.CoreComponents.StateMachine
{
	[CreateAssetMenu(fileName = "LandState", menuName = "PlayerStates/Land")]
	public class Land : PlayerState
	{
        private readonly PlayerAnimator _playerAnimator;
        private PlayerAnimator PlayerAnimator
        {
            get => _playerAnimator != null ? _playerAnimator : _context.GetCoreComponent<PlayerAnimator>();
        }
        private readonly StateMachineComponent _stateMachine;
        private StateMachineComponent StateMachine
        {
            get => _stateMachine != null ? _stateMachine : _context.GetCoreComponent<StateMachineComponent>();
        }

        private float _stateDuration;
        public override void Enter()
        {
            _stateDuration = animations[0].length;
            PlayerAnimator.PlayAnimation(animations[0]);
        }
        public override void LogicUpdate()
        {
            _stateDuration -= Time.deltaTime;
            if (_stateDuration <= 0)
                TransitionToRun();
        }
        private void TransitionToRun()
        {
            StateMachine.StateMachine.SwitchState(StateMachine.runState);
        }
    }
}