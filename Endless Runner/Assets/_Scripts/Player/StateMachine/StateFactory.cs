namespace TheCreators.Player
{
    public class StateFactory
    {
        private readonly Player _context;
        public StateFactory(Player currentContext)
        {
            _context = currentContext;
        }
        public State Run()
        {
            return new RunState(_context);
        }
        public State Jump()
        {
            return new JumpState(_context);
        }
        public State Fly()
        {
            return new FlyState(_context);
        }
        public State Dig()
        {
            return new DigState(_context);
        }
        public State Fall()
        {
            return new FallState(_context);
        }
    }
}
