namespace TheCreators.Player
{
    public class FallState : State
    {
        private float fallGravityMultiplier = 3f;
        public FallState(Player currentContext) : base(currentContext) { }
        public override void Enter()
        {
            ApplyGravityMultiplier();
        }
        public override void ExitState()
        {
            CancelGravityMultiplier();
        }
        public override void LogicUpdate()
        {
            if (_context.CollisionSenses.Grounded)
            {
                _context.StateMachine.SwitchState(_context.StateFactory.Run());
            }
            if (_context.InputManager.FlyPerformed)
            {
                _context.StateMachine.SwitchState(_context.StateFactory.Fly());
            }
        }
        private void ApplyGravityMultiplier()
        {
            _context.RB.gravityScale *= fallGravityMultiplier;
        }
        private void CancelGravityMultiplier()
        {
            _context.RB.gravityScale /= fallGravityMultiplier;
        }
    }
}