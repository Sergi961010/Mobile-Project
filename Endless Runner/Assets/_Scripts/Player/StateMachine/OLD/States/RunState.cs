namespace TheCreators.Player
{
    public class RunState : State
    {
        public RunState(Player currentContext) : base (currentContext) { }
        public override void LogicUpdate()
        {
            if (_context.InputManager.JumpPerformed)
            {
                _context.StateMachine.SwitchState(_context.StateFactory.Jump());
                _context.InputManager.UseJumpInput();
            }
            if (_context.InputManager.SwipeDetection.BurrowPerformed)
            {
                _context.StateMachine.SwitchState(_context.StateFactory.Dig());
            }
        }
    }
}
