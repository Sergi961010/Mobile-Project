using UnityEngine;

namespace TheCreators.Player
{
    [CreateAssetMenu(fileName = "FlyState", menuName = "PlayerStates/Fly")]
    public class NewFlyState : NewPlayerState
    {
        public float defaultForce = 20f;
        public float smoothFactor = .2f;
        public override void Enter()
        {
            ApplyGravityMultiplier();
            HandleYVelocity();
            _context.PlayerAnimator.PlayLockedAnimation(animations[0]);
        }

        public override void LogicUpdate()
        {
            _context.PlayerAnimator.PlayAnimation(animations[1]);
            if (!_context.InputManager.FlyPerformed)
            {
                _context.StateMachine.SwitchState(_context.fallState);
            }
        }
        public override void Exit()
        {
            _context.PlayerAnimator.PlayAnimation(animations[2]);
            CancelGravityMultiplier();
        }
        public override void PhysicsUpdate()
        {
            HandleFly();
        }
        private void HandleFly()
        {
            _context.RB.AddForce(Vector2.up * defaultForce, ForceMode2D.Force);
        }
        private void ApplyGravityMultiplier()
        {
            _context.RB.gravityScale *= smoothFactor;
        }
        private void CancelGravityMultiplier()
        {
            _context.RB.gravityScale /= smoothFactor;
        }
        private void HandleYVelocity()
        {
            _context.RB.velocity = new Vector2(_context.RB.velocity.x, _context.RB.velocity.y * smoothFactor);
        }
    }
}