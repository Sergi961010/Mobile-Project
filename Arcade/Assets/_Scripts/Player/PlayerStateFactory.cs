using TheCreators.Player.ConcreteStates;

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
            return new Run(_context, this);
        }

        public PlayerBaseState Attack()
        {
            return new Attack(_context, this);
        }
    }
}
