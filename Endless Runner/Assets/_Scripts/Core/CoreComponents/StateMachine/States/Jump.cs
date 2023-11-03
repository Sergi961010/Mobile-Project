using TheCreators.Managers;
using UnityEngine;

namespace TheCreators.Player.StateMachine.States
{
    [CreateAssetMenu(fileName = "JumpState", menuName = "PlayerStates/Jump")]
    public class Jump : PlayerState
    {
        public float jumpHeight = 2f;
        public float jumpTimeToApex = .5f;
        public float jumpHangTimeThreshold = .1f;
        public float jumpHangGravityMultiplier = .5f;
        public float transitionToFlyThreshold = .5f;
        public override void Enter()
        {
            _context.Movement.Jump(jumpHeight, jumpTimeToApex);
            _context.PlayerAnimator.PlayAnimation(animations[0]);
            SoundManager.Instance.PlayAudioEvent(audioEvent);
        }
        public override void LogicUpdate()
        {
            if (_context.InputController.IsFlying) TransitionToFly();

            if (_context.Movement.Rigidbody.velocity.y < -jumpHangTimeThreshold) TransitionToInAir();
        }
        public override void PhysicsUpdate()
        {
        }
        public override void Exit()
        {
        }
        private void TransitionToFly()
        {
            if(_context.Movement.Rigidbody.position.y >= -transitionToFlyThreshold)
                _context.StateMachine.StateMachine.SwitchState(_context.StateMachine.flyState);
        }
        private void TransitionToInAir()
        {
            _context.StateMachine.StateMachine.SwitchState(_context.StateMachine.inAirState);
        }
    }
}
