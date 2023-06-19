using TheCreators.CustomEventSystem;
using TheCreators.Player.Input;
using TheCreators.ScriptableObjects;
using UnityEngine;

namespace TheCreators.Player.StateMachine
{
    public class StateMachine : MonoBehaviour
    {
        private StateFactory _stateFactory;
        public State CurrentState { get; set; }
        [field: SerializeField]
        public CollisionSenses CollisionSenses { get; set; }
        [field: SerializeField]
        public PlayerInputManager InputManager { get; set; }
        [field: SerializeField]
        public RunData RunData { get; set; }
        [field: SerializeField]
        public JumpData JumpData { get; set; }
        public Rigidbody2D Rigidbody { get; private set; }

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody2D>();
            _stateFactory = new StateFactory(this);
            CurrentState = _stateFactory.Run();
            CurrentState.Enter();
        }
        private void Update()
        {
            CurrentState.LogicUpdate();
        }
        private void FixedUpdate()
        {
            CurrentState.PhysicsUpdate();
        }
    }
}
