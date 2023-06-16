using UnityEngine;

namespace TheCreators.Player.StateMachine
{
    public class FallState : State
    {
        public FallState(StateMachine currentContext, StateFactory stateFactory) : base(currentContext, stateFactory) { }
        public override void CheckSwitchState()
        {
            if (_context.InputManager.FlyPerformed)
                SwitchState(_stateFactory.Fly());
            if (_context.CollisionSenses.Grounded)
                SwitchState(_stateFactory.Run());
        }
        public override void Enter()
        {
            Debug.Log("Enter Fall");
        }
        public override void ExitState()
        {
            Debug.Log("Exit Fall");
        }
        public override void LogicUpdate()
        {
            CheckSwitchState();
        }
        public override void PhysicsUpdate()
        {
            HandleGravity();
        }

        private void HandleGravity()
        {
            _context.Rigidbody.gravityScale = _context.JumpData.gravityScale * _context.JumpData.fallGravityMultiplier;
        }
    }
}
