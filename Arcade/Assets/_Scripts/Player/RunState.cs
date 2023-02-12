using UnityEngine;

namespace TheCreators.Player
{
    public class RunState : PlayerBaseState
    {
        public RunState(PlayerStateMachine context, PlayerStateFactory playerStateFactory) : base (context, playerStateFactory)
        {
            _context = context;
            _playerStateFactory = playerStateFactory;
        }

        private void HandleAttackInput()
        {
            SwitchState(_playerStateFactory.Attack());
        }

        public override void EnterState()
        {
            SetVeloicty(_context._playerData.Speed);
            PlayerInput.OnAttackInput += HandleAttackInput;
        }

        public override void ExitState()
        {
            PlayerInput.OnAttackInput -= HandleAttackInput;
        }

        private void SetVeloicty(float speed)
        {
            _context.RigidBody.velocity = Vector2.right * speed;
        }
    }
}
