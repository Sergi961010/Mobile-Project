using TheCreators.CustomEventSystem;
using UnityEngine;

namespace TheCreators.Player.StateMachine
{
    public class JumpState : State
    {
        public JumpState(StateMachine currentContext, StateFactory stateFactory) : base(currentContext, stateFactory) { }

        public override void Enter()
        {
            HandleJump();
            //Debug.Log("Enter Jump");
        }
        public override void LogicUpdate()
        {
            CheckSwitchState();
        }
        public override void PhysicsUpdate()
        {
            HandleGravity();
        }
        public override void ExitState()
        {
            //Debug.Log("Exit Jump");
        }
        public override void CheckSwitchState()
        {
            if (_context.Rigidbody.velocity.y < -_context.JumpData.jumpHangTimeThreshold)
            {
                SwitchState(_stateFactory.Fall());
            }
            if (_context.InputManager.FlyPerformed)
            {
                SwitchState(_stateFactory.Fly());
            }
        }
        private void HandleJump()
        {
            _context.Rigidbody.AddForce(Vector2.up * _context.JumpData.jumpForce, ForceMode2D.Impulse);
        }
        private void HandleGravity()
        {
            if (Mathf.Abs(_context.Rigidbody.velocity.y) < _context.JumpData.jumpHangTimeThreshold)
                _context.Rigidbody.gravityScale = _context.JumpData.gravityScale * _context.JumpData.jumpHangGravityMultiplier;
        }
    }
}
