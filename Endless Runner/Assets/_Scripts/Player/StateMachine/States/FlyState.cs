using UnityEngine;

namespace TheCreators.Player
{
    public class FlyState : State
    {
        private readonly float defaultForce = 20f;
        private readonly float smoothFactor = .2f;
        public FlyState(Player currentContext) : base(currentContext) { }
        public override void Enter()
        {
            ApplyGravityMultiplier();
            HandleYVelocity();
        }

        public override void LogicUpdate()
        {
            if (!_context.InputManager.FlyPerformed)
            {
                _context.StateMachine.SwitchState(_context.StateFactory.Fall());
            }
        }
        public override void ExitState()
        {
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