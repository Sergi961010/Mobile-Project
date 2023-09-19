using UnityEngine;

namespace TheCreators.Player
{
    [CreateAssetMenu(fileName = "JumpState", menuName = "PlayerStates/Jump")]
    public class NewJumpState : NewPlayerState
    {
        public float gravityStrength;
        public float gravityScale;
        public float jumpForce;
        public float jumpHeight = 2f;
        public float jumpTimeToApex = .5f;
        public float jumpHangTimeThreshold = .1f;
        public float jumpHangGravityMultiplier = .5f;

        public override void Enter()
        {
            CalculateJumpForce();
            HandleJump();
            _context.PlayerAnimator.PlayAnimation(animations[0]);
        }
        public override void LogicUpdate()
        {
            if (_context.RB.velocity.y < -jumpHangTimeThreshold)
            {
                _context.StateMachine.SwitchState(_context.fallState);
            }
        }
        public override void PhysicsUpdate()
        {
            //HandleGravity();
        }
        public override void Exit()
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
