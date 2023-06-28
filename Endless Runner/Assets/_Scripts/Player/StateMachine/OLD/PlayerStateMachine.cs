namespace TheCreators.Player
{
    public class PlayerStateMachine
    {
        public State CurrentState { get; set; }
        public void Initialize(State startingState)
        {
            CurrentState = startingState;
            CurrentState.Enter();
        }
        public void SwitchState(State newState)
        {
            CurrentState.ExitState();
            CurrentState = newState;
            CurrentState.Enter();
        }
    }
}