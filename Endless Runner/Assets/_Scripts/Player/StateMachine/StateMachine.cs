using UnityEngine;

namespace TheCreators.Player.StateMachine
{
    public class StateMachine : MonoBehaviour
    {
        public State CurrentState { get; set; }
        private StateFactory _stateFactory;

        private void Awake()
        {
            _stateFactory = new StateFactory(this);
            CurrentState = _stateFactory.Run();
            CurrentState.EnterState();
        }
    }
}
