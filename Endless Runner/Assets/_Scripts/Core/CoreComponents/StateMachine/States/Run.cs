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
            /*_context.InputManager.JumpAction.Enable();
            _context.InputManager.SwipeDetection.enabled = true;*/
            GameEvent.OnPerformJump.AddListener(TransitionToJump);
            GameEvent.OnPerformBurrow.AddListener(TransitionToDig);
        }
        public override void LogicUpdate()
        {
            _context.PlayerAnimator.PlayAnimation(_animations[0]);
        }
        public override void PhysicsUpdate()
        {
            //_context.Movement.Run(_speed);
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