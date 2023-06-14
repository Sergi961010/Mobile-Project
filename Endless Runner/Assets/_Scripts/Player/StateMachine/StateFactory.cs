namespace TheCreators.Player.StateMachine
{
    public class StateFactory
    {
        StateMachine _context;

        public StateFactory(StateMachine currentContext)
        {
            _context = currentContext;
        }

        public State Run()
        {
            return new RunState();
        }
        public State Jump()
        {
            return new JumpState();
        }
        public State Fly()
        {
            return new FlyState();
        }
        public State Dig()
        {
            return new DigState();
        }
    }
}
