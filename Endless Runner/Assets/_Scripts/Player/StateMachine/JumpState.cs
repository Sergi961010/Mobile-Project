using UnityEngine;

namespace TheCreators.Player.StateMachine
{
    public class JumpState : State
    {
        public JumpState(StateMachine currentContext, StateFactory stateFactory) : base(currentContext, stateFactory) { }

        public override void Enter()
        {
            HandleJump();
            Debug.Log("Enter Jump");
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
            Debug.Log("Exit Jump");
        }
        public override void CheckSwitchState()
        {
            Debug.Log("Ground Check: " + _context.CollisionSenses.Grounded);
            if (_context.CollisionSenses.Grounded && _context.Rigidbody.velocity.y < 0.01f)
            {
                Debug.Log("Switch Run");
                SwitchState(_stateFactory.Run());
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
            else if (_context.Rigidbody.velocity.y < 0)
                _context.Rigidbody.gravityScale = _context.JumpData.gravityScale * _context.JumpData.fallGravityMultiplier;
        }
    }
}
