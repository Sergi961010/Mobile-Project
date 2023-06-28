using UnityEngine;

namespace TheCreators.Player
{
    public class JumpState : State
    {
        private float gravityStrength;
        private float gravityScale;
        private float jumpForce;
        private float jumpHeight = 2f;
        private float jumpTimeToApex = .5f;
        private float jumpHangTimeThreshold = .1f;
        private float jumpHangGravityMultiplier = .5f;

        public JumpState(Player currentContext) : base(currentContext) { }

        public override void Enter()
        {
            CalculateJumpForce();
            HandleJump();
        }
        public override void LogicUpdate()
        {
            if (_context.RB.velocity.y < -jumpHangTimeThreshold)
            {
                _context.StateMachine.SwitchState(_context.StateFactory.Fall());
            }
        }
        public override void PhysicsUpdate()
        {
            //HandleGravity();
        }
        public override void ExitState()
        {
            
        }
        private void HandleJump()
        {
            _context.RB.gravityScale = gravityScale;
            _context.RB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        private void HandleGravity()
        {
            if (Mathf.Abs(_context.RB.velocity.y) < jumpHangTimeThreshold)
                _context.RB.gravityScale *= jumpHangGravityMultiplier;
            else
                _context.RB.gravityScale = gravityScale;
        }
        private void CalculateJumpForce()
        {
            gravityStrength = -(2 * jumpHeight) / Mathf.Pow(jumpTimeToApex, 2);

            gravityScale = gravityStrength / Physics2D.gravity.y;

            jumpForce = Mathf.Abs(gravityStrength) * jumpTimeToApex;
        }
    }
}
