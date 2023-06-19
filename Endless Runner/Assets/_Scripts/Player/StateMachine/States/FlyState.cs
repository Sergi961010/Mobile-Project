using UnityEngine;

namespace TheCreators.Player.StateMachine
{
    public class FlyState : State
    {
        private readonly float defaultForce = 20f;
        private readonly float smoothFactor = .5f;

        public FlyState(StateMachine currentContext, StateFactory stateFactory) : base(currentContext, stateFactory) { }
        public override void Enter()
        {
            HandleGravity();
            Debug.Log("Enter Fly");
        }
        private void HandleGravity()
        {
            _context.Rigidbody.gravityScale = _context.JumpData.gravityScale * smoothFactor;
            _context.Rigidbody.velocity = new Vector2(_context.Rigidbody.velocity.x, _context.Rigidbody.velocity.y * smoothFactor);
        }
        public override void LogicUpdate()
        {
            CheckSwitchState();
        }
        public override void ExitState()
        {
            Debug.Log("Exit Fly");
        }
        public override void CheckSwitchState()
        {
            if (!_context.InputManager.FlyPerformed)
                SwitchState(_stateFactory.Fall());
            if (_context.CollisionSenses.Grounded)
                SwitchState(_stateFactory.Run());
        }
        public override void PhysicsUpdate()
        {
            HandleFly();
        }
        private void HandleFly()
        {
            _context.Rigidbody.AddForce(Vector2.up * defaultForce, ForceMode2D.Force);
        }
    }
}