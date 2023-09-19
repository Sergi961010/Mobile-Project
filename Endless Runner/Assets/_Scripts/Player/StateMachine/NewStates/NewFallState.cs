using UnityEngine;

namespace TheCreators.Player
{
    [CreateAssetMenu(fileName = "FallState", menuName = "PlayerStates/Fall")]
    public class NewFallState : NewPlayerState
    {
        public float fallGravityMultiplier = 3f;
        public override void Enter()
        {
            _context.PlayerAnimator.PlayAnimation(animations[0]);
            ApplyGravityMultiplier();
        }
        public override void Exit()
        {
            CancelGravityMultiplier();
        }
        public override void LogicUpdate()
        {
            if (_context.CollisionSenses.Grounded)
            {
                _context.StateMachine.SwitchState(_context.runState);
            }
            if (_context.InputManager.FlyPerformed)
            {
                _context.StateMachine.SwitchState(_context.flyState);
            }
        }
        private void ApplyGravityMultiplier()
        {
            _context.RB.gravityScale *= fallGravityMultiplier;
        }
        private void CancelGravityMultiplier()
        {
            _context.RB.gravityScale /= fallGravityMultiplier;
        }
    }
}