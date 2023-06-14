using UnityEngine;

namespace TheCreators.Player.StateMachine
{
    public class RunState : State
    {
        public RunState(StateMachine currentContext, StateFactory stateFactory) : base (currentContext, stateFactory) { }

        public override void Enter()
        {
            HandleGravity();
            Debug.Log("Enter Run");
        }
        public override void LogicUpdate()
        {
            CheckSwitchState();
        }
        public override void PhysicsUpdate()
        {
            HandleRun();
        }
        public override void ExitState() { }
        public override void CheckSwitchState()
        {
            if (_context.InputManager.JumpPressed)
            {
                _context.InputManager.UseJumpInput();
                Debug.Log("Switch to Jump");
                SwitchState(_stateFactory.Jump());
            }
        }
        private void HandleRun()
        {
            _context.Rigidbody.velocity = new Vector2(_context.RunData.Speed, _context.Rigidbody.velocity.y);
        }
        private void HandleGravity()
        {
            _context.Rigidbody.gravityScale = _context.JumpData.gravityScale;
        }
    }
}
