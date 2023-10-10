using TheCreators.Managers;
using UnityEngine;

namespace TheCreators.Player.StateMachine.States
{
    [CreateAssetMenu(fileName = "JumpState", menuName = "PlayerStates/Jump")]
    public class Jump : PlayerState
    {
        public float jumpHeight = 2f;
        public float jumpTimeToApex = .5f;
        public float jumpHangTimeThreshold = .1f;
        public float jumpHangGravityMultiplier = .5f;

        public override void Enter()
        {
            _context.Movement.Jump(jumpHeight, jumpTimeToApex);
            _context.PlayerAnimator.PlayAnimation(_animations[0]);
            SoundManager.Instance.PlaySound(_audioClip);
            _context.InputManager.PrimaryTouch.Disable();
        }
        public override void LogicUpdate()
        {
            if (_context.Movement.Rigidbody.velocity.y < -jumpHangTimeThreshold)
            {
                _context.StateMachine.StateMachine.SwitchState(_context.StateMachine.inAirState);
            }
        }
        public override void PhysicsUpdate()
        {
        }
        public override void Exit()
        {
        }
    }
}
