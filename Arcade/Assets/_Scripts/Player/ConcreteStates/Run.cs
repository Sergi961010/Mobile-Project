using UnityEngine;

namespace TheCreators.Player.ConcreteStates
{
    public class Run : PlayerBaseState
    {
        public Run(PlayerStateMachine context, PlayerStateFactory playerStateFactory) : base (context, playerStateFactory)
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
            PlayerInput.OnAttackInput += HandleAttackInput;
            _context.Anim.Play(GetType().Name);
            SetVeloicty(_context._playerData.Speed);
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
