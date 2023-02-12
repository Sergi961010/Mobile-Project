using TheCreators.ScriptableObjects;
using UnityEngine;

namespace TheCreators.Player
{
    public class PlayerStateMachine : MonoBehaviour
    {
        public PlayerData _playerData;

        public PlayerBaseState CurrentState { get; set; }

        public PlayerStateFactory PlayerStateFactory { get; private set; }

        public Rigidbody2D RigidBody { get; private set; }
        public Animator Anim { get; private set; }

        private void Awake()
        {
            PlayerStateFactory = new PlayerStateFactory(this);

            RigidBody = GetComponent<Rigidbody2D>();
            Anim = GetComponent<Animator>();
        }

        private void Start()
        {
            CurrentState = PlayerStateFactory.Run();
            CurrentState.EnterState();
        }
    }
}
