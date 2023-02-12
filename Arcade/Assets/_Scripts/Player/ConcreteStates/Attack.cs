namespace TheCreators.Player
{
    public class Attack : PlayerBaseState
    {
        public Attack(PlayerStateMachine context, PlayerStateFactory playerStateFactory) : base (context, playerStateFactory)
        {
            _context = context;
            _playerStateFactory = playerStateFactory;
        }

        private void HandleAnimationFinish()
        {
            SwitchState(_playerStateFactory.Run());
        }

        public override void EnterState()
        {
            PlayerAnimationController.OnAnimationFinish += HandleAnimationFinish;
            _context.Anim.Play(GetType().Name);
        }
        public override void ExitState()
        {
            PlayerAnimationController.OnAnimationFinish += HandleAnimationFinish;
        }
    }
}
