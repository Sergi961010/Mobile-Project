using TheCreators.Player.Input;
using UnityEngine;

namespace TheCreators.Player
{
    public class NewPlayer : MonoBehaviour
    {
        private float jumpHeight = 2f;
        private float jumpTimeToApex = .5f;
        private float gravityStrength;
        private float gravityScale;

        #region States
        public IState runState;
        public IState jumpState;
        public IState fallState;
        public IState flyState;
        public IState digState;
        #endregion

        public NewPlayerStateMachine StateMachine { get; private set; }
        public NewStateFactory StateFactory { get; private set; }

        [field: SerializeField] public PlayerInputManager InputManager { get; private set; }
        public Rigidbody2D RB { get; private set; }
        public CollisionSenses CollisionSenses { get; private set; }
        private void Awake()
        {
            StateMachine = new NewPlayerStateMachine();
            StateFactory = new NewStateFactory(this);

            RB = GetComponent<Rigidbody2D>();
            CollisionSenses = GetComponentInChildren<CollisionSenses>();

            CalculateGravityValues();
        }
        private void Start()
        {
            runState.Init(this);
            jumpState.Init(this);
            fallState.Init(this);
            flyState.Init(this);
            digState.Init(this);

            RB.gravityScale = gravityScale;
            StateMachine.Initialize(runState);
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