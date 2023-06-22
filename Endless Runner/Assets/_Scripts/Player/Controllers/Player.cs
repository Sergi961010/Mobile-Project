using TheCreators.Player.Input;
using UnityEngine;

namespace TheCreators.Player
{
    public class Player : MonoBehaviour
    {
        private float jumpHeight = 2f;
        private float jumpTimeToApex = .5f;
        private float gravityStrength;
        private float gravityScale;
        private float _speed = 6f;

        public PlayerStateMachine StateMachine { get; private set; }
        public StateFactory StateFactory { get; private set; }

        [field: SerializeField] public PlayerInputManager InputManager { get; private set; }
        public Rigidbody2D RB { get; private set; }
        public CollisionSenses CollisionSenses { get; private set; }
        private void Awake()
        {
            StateMachine = new PlayerStateMachine();
            StateFactory = new StateFactory(this);

            RB = GetComponent<Rigidbody2D>();
            CollisionSenses = GetComponentInChildren<CollisionSenses>();

            CalculateGravityValues();
        }
        private void Start()
        {
            RB.gravityScale = gravityScale;
            RB.velocity = new Vector2(_speed, 0);
            StateMachine.Initialize(StateFactory.Run());
        }
        private void Update()
        {
            StateMachine.CurrentState.LogicUpdate();
        }
        private void FixedUpdate()
        {
            StateMachine.CurrentState.PhysicsUpdate();
        }
        private void CalculateGravityValues()
        {
            gravityStrength = -(2 * jumpHeight) / Mathf.Pow(jumpTimeToApex, 2);
            gravityScale = gravityStrength / Physics2D.gravity.y;
        }
    }
}
