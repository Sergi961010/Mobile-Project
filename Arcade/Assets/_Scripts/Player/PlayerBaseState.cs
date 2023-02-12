namespace TheCreators.Player
{
    public abstract class PlayerBaseState
    {
        protected PlayerStateMachine _context;
        protected PlayerStateFactory _playerStateFactory;

        public PlayerBaseState(PlayerStateMachine context, PlayerStateFactory playerStateFactory)
        {
            _context = context;
            _playerStateFactory = playerStateFactory;
        }
        public abstract void EnterState();
        public abstract void ExitState();
        public void SwitchState(PlayerBaseState newState)
        {
            ExitState();
            newState.EnterState();
            _context.CurrentState = newState;
        }
    }
}
