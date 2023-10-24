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
            _context.PlayerAnimator.PlayAnimation(_animations[0]);
        }
        public override void LogicUpdate()
        {
            if (_context.InputController.CanJump) 
                TransitionToJump();
            if (_context.InputController.CanBurrow)
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
            _context.StateMachine.StateMachine.SwitchState(_context.StateMachine.jumpState);
        }
        private void TransitionToDig()
        {
            _context.StateMachine.StateMachine.SwitchState(_context.StateMachine.digState);
        }
    }
}