using TheCreators.CustomEventSystem;
using UnityEngine;

namespace TheCreators.Player.StateMachine.States
{
    [CreateAssetMenu(fileName = "RunState", menuName = "PlayerStates/Run")]
    public class Run : PlayerState
    {
        public float _speed = 6f;
        public override void Enter()
        {
            GameEvent.OnPerformJump.AddListener(TransitionToJump);
            GameEvent.OnPerformBurrow.AddListener(TransitionToDig);
            _context.PlayerAnimator.PlayAnimation(_animations[0]);
        }
        public override void LogicUpdate()
        {
        }
        public override void PhysicsUpdate()
        {
        }
        public override void Exit()
        {
            GameEvent.OnPerformJump.RemoveListener(TransitionToJump);
            GameEvent.OnPerformBurrow.RemoveListener(TransitionToDig);
        }
        private void TransitionToJump()
        {
            _context.StateMachine.StateMachine.SwitchState(_context.StateMachine.jumpState);
        }
        private void TransitionToDig()
        {
            _context.StateMachine.StateMachine.SwitchState(_context.StateMachine.digState);
        }
    }
}