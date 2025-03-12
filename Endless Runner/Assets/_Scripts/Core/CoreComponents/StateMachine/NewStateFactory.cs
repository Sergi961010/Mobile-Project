using TheCreators.CoreSystem;
using TheCreators.CoreSystem.CoreComponents.StateMachine;
using TheCreators.Player.StateMachine.States;
using UnityEngine;

namespace TheCreators.Player.StateMachine
{
    public class NewStateFactory
    {
        private readonly Core _context;
        public NewStateFactory(Core currentContext)
        {
            _context = currentContext;
        }
        public PlayerState Run()
        {
            PlayerState state = ScriptableObject.CreateInstance<Run>();
            state.Init(_context);
            return state;
        }
        public PlayerState Jump()
        {
            PlayerState state = ScriptableObject.CreateInstance<Jump>();
            state.Init(_context);
            return state;
        }
        public PlayerState Fly()
        {
            PlayerState state = ScriptableObject.CreateInstance<Fly>();
            state.Init(_context);
            return state;
        }
        public PlayerState Dig()
        {
            PlayerState state = ScriptableObject.CreateInstance<DigLoop>();
            state.Init(_context);
            return state;
        }
        public PlayerState InAir()
        {
            PlayerState state = ScriptableObject.CreateInstance<InAir>();
            state.Init(_context);
            return state;
        }
    }
}
