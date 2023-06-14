namespace TheCreators.Player.StateMachine
{
    public class StateFactory
    {
        private readonly StateMachine _context;
        public StateFactory(StateMachine currentContext)
        {
            _context = currentContext;
        }

        public State Run()
        {
            return new RunState(_context, this);
        }
        public State Jump()
        {
            return new JumpState(_context, this);
        }
        public State Fly()
        {
            return new FlyState(_context, this);
        }
        public State Dig()
        {
            return new DigState(_context, this);
        }
    }
}
