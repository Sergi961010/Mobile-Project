using TheCreators.CustomEventSystem;
using UnityEngine;

namespace TheCreators.Player.StateMachine.States
{
    [CreateAssetMenu(fileName = "InAirState", menuName = "PlayerStates/InAir")]
    public class InAir : PlayerState
    {
        public float fallGravityMultiplier = 3f;
        public override void Enter()
        {
            _context.PlayerAnimator.PlayAnimation(animations[0]);
            _context.Movement.ModifyGravity(fallGravityMultiplier);
        }
        public override void Exit()
        {
        }
        public override void LogicUpdate()
        {
            if (_context.CollisionSenses.Grounded) TransitionToRun();
            if (_context.InputController.IsFlying) TransitionToFly();
        }
        private void TransitionToRun()
        {
            _context.StateMachine.StateMachine.SwitchState(_context.StateMachine.runState);
        }
        private void TransitionToFly()
        {
            _context.StateMachine.StateMachine.SwitchState(_context.StateMachine.flyState);
        }
    }
}