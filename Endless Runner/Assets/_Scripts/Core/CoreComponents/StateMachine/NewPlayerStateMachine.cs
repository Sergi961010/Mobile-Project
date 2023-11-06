namespace TheCreators.CoreSystem.CoreComponents.StateMachine
{
    public class NewPlayerStateMachine
    {
        public IState CurrentState { get; set; }
        public void Initialize(IState startingState)
        {
            CurrentState = startingState;
            CurrentState.Enter();
        }
        public void SwitchState(IState newState)
        {
            CurrentState.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }
    }
}