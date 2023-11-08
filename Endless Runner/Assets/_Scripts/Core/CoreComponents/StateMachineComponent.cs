using TheCreators.CoreSystem.CoreComponents.StateMachine;

namespace TheCreators.CoreSystem.CoreComponents
{
    public class StateMachineComponent : BaseCoreComponent
    {
        #region States
        public Run runState;
        public Jump jumpState;
        public InAir inAirState;
        public Fly flyState;
        public DigEnter digEnterState;
        public DigLoop digLoopState;
        public DigExit digExitState;
        #endregion

        public NewPlayerStateMachine StateMachine { get; private set; }
        protected override void Awake()
        {
            base.Awake();
            StateMachine = new NewPlayerStateMachine();
        }
        private void Start()
        {
            runState.Init(Core);
            jumpState.Init(Core);
            inAirState.Init(Core);
            flyState.Init(Core);
            digEnterState.Init(Core);
            digLoopState.Init(Core);
            digExitState.Init(Core);

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
    }
}