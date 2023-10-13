using UnityEngine;

namespace TheCreators.Player.StateMachine.States
{
    [CreateAssetMenu(fileName = "RunState", menuName = "PlayerStates/Run")]
    public class Run : PlayerState
    {
        public float _speed = 6f;
        public override void Enter()
        {
            _context.InputManager.JumpAction.Enable();
            _context.InputManager.PrimaryTouch.Enable();
        }
        public override void LogicUpdate()
        {
            _context.PlayerAnimator.PlayAnimation(_animations[0]);
            if (_context.InputManager.JumpPerformed)
            {
                _context.StateMachine.StateMachine.SwitchState(_context.StateMachine.jumpState);
                _context.InputManager.UseJumpInput();
            }
            if (_context.InputManager.SwipeDetection.BurrowPerformed)
            {
                _context.StateMachine.StateMachine.SwitchState(_context.StateMachine.digState);
            }
        }
        public override void PhysicsUpdate()
        {
            //_context.Movement.SetXVelocity(_speed);
        }
        public override void Exit()
        {
            _context.InputManager.JumpAction.Disable();
        }
    }
}
