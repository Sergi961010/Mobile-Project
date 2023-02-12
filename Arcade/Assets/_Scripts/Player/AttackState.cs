namespace TheCreators.Player
{
    public class AttackState : PlayerBaseState
    {
        public AttackState(PlayerStateMachine context, PlayerStateFactory playerStateFactory) : base (context, playerStateFactory)
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
            _context.Anim.SetBool("attack", true);
            PlayerAnimationController.OnAnimationFinish += HandleAnimationFinish;
        }
        public override void ExitState()
        {
            _context.Anim.SetBool("attack", false);
        }
    }
}
