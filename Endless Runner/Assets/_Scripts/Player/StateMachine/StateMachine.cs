using UnityEngine;

namespace TheCreators.Player.StateMachine
{
    public class StateMachine : MonoBehaviour
    {
        private State _currentState;
        private StateFactory _stateFactory;

        private void Awake()
        {
            _stateFactory = new StateFactory(this);
            _currentState = _stateFactory.Run();
            _currentState.EnterState();
        }
    }
}
