using UnityEngine;

namespace TheCreators.Player
{
    public class NewStateFactory
    {
        private readonly NewPlayer _context;
        public NewStateFactory(NewPlayer currentContext)
        {
            _context = currentContext;
        }
        public NewPlayerState Run()
        {
            NewPlayerState state = ScriptableObject.CreateInstance<NewRunState>();
            state.Init(_context);
            return state;
        }
        public NewPlayerState Jump()
        {
            NewPlayerState state = ScriptableObject.CreateInstance<NewJumpState>();
            state.Init(_context);
            return state;
        }
        public NewPlayerState Fly()
        {
            NewPlayerState state = ScriptableObject.CreateInstance<NewFlyState>();
            state.Init(_context);
            return state;
        }
        public NewPlayerState Dig()
        {
            NewPlayerState state = ScriptableObject.CreateInstance<NewDigState>();
            state.Init(_context);
            return state;
        }
        public NewPlayerState Fall()
        {
            NewPlayerState state = ScriptableObject.CreateInstance<NewFallState>();
            state.Init(_context);
            return state;
        }
    }
}
