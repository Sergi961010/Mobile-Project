using UnityEngine;

namespace TheCreators.Player.StateMachine.States
{
    [CreateAssetMenu(fileName = "InAirState", menuName = "PlayerStates/InAir")]
    public class InAir : PlayerState
    {
        public float fallGravityMultiplier = 3f;
        public override void Enter()
        {
            _context.PlayerAnimator.PlayAnimation(_animations[0]);
            _context.Movement.ModifyGravity(fallGravityMultiplier);
            _context.InputManager.FlyAction.Enable();
        }
        public override void Exit()
        {
            //_context.Movement.ResetGravityScale();
        }
        public override void LogicUpdate()
        {
            if (_context.CollisionSenses.Grounded)
            {
                _context.StateMachine.StateMachine.SwitchState(_context.StateMachine.runState);
            }
            if (_context.InputManager.FlyPerformed)
            {
                _context.StateMachine.StateMachine.SwitchState(_context.StateMachine.flyState);
            }
        }
    }
}