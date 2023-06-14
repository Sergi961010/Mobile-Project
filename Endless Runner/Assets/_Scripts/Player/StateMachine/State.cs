namespace TheCreators.Player.StateMachine
{
    public abstract class State
    {
        protected StateMachine _context;
        protected StateFactory _stateFactory;

        public State(StateMachine currentContext, StateFactory stateFactory)
        {
            _context = currentContext;
            _stateFactory = stateFactory;
        }

        public abstract void EnterState();
        public abstract void UpdateState();
        public abstract void ExitState();
        public abstract void CheckSwitchState();
        private void SwitchState(State newState)
        {
            ExitState();
            newState.EnterState();
            _context.CurrentState = newState;
        }
    }
}
