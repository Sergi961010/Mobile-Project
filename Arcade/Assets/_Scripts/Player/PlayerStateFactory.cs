namespace TheCreators.Player
{
    public class PlayerStateFactory
    {
        private PlayerStateMachine _context;

        public PlayerStateFactory(PlayerStateMachine context)
        {
            _context = context;
        }

        public PlayerBaseState Run()
        {
            return new RunState(_context, this);
        }

        public PlayerBaseState Attack()
        {
            return new AttackState(_context, this);
        }
    }
}
