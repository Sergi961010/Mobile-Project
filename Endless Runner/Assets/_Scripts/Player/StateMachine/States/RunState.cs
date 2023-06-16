using TheCreators.CustomEventSystem;
using UnityEngine;

namespace TheCreators.Player.StateMachine
{
    public class RunState : State
    {
        public RunState(StateMachine currentContext, StateFactory stateFactory) : base (currentContext, stateFactory) { }

        public override void Enter()
        {
            HandleGravity();
            HandleRun();
            //Debug.Log("Enter Run");
        }
        public override void LogicUpdate()
        {
            CheckSwitchState();
        }
        public override void PhysicsUpdate()
        {
            //HandleRun();
        }
        public override void ExitState() {
            //Debug.Log("Exit Run");
        }
        public override void CheckSwitchState()
        {
            if (_context.InputManager.JumpPerformed)
            {
                _context.InputManager.UseJumpInput();
                SwitchState(_stateFactory.Jump());
            }
            if (_context.InputManager.SwipeDetection.BurrowPerformed)
            {
                _context.InputManager.SwipeDetection.UseBurrow();
                SwitchState(_stateFactory.Dig());
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
