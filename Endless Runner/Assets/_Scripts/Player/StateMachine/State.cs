using UnityEngine;

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

        public abstract void Enter();
        public abstract void LogicUpdate();
        public abstract void PhysicsUpdate();
        public abstract void ExitState();
        public abstract void CheckSwitchState();
        protected void SwitchState(State newState)
        {
            ExitState();
            newState.Enter();
            _context.CurrentState = newState;
        }
    }
}
