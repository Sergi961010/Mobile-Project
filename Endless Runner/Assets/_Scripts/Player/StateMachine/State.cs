namespace TheCreators.Player
{
    public class State
    {
        protected Player _context;
        public State(Player currentContext)
        {
            _context = currentContext;
        }
        public virtual void Enter() { }
        public virtual void LogicUpdate() { }
        public virtual void PhysicsUpdate() { }
        public virtual void ExitState() { }
    }
}