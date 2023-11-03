using TheCreators.Managers;
using UnityEngine;

namespace TheCreators.Player.StateMachine.States
{
    [CreateAssetMenu(fileName = "FlyState", menuName = "PlayerStates/Fly")]
    public class Fly : PlayerState
    {
        public float defaultForce = 20f;
        public float smoothFactor = .2f;
        public float staminaCost = 20f;
        public override void Enter()
        {
            _context.Movement.ModifyGravity(smoothFactor);
            _context.Movement.ModifyYVelocity(smoothFactor);
            _context.PlayerAnimator.PlayAnimation(animations[0]);
            SoundManager.Instance.PlayAudioEvent(audioEvent);
            _context.Stamina.CanRegenerate = false;
        }
        public override void LogicUpdate()
        {
            _context.PlayerAnimator.PlayAnimation(animations[1]);
            _context.Stamina.SubstractStamina(staminaCost);
            if (!_context.InputController.IsFlying || _context.Stamina.CurrentStamina == 0)
                TransitionToInAir();
        }
        public override void PhysicsUpdate()
        {
            _context.Movement.Fly(defaultForce);
        }
        public override void Exit()
        {
            _context.PlayerAnimator.PlayLockedAnimation(animations[2]);
            _context.Movement.ResetGravityScale();
            _context.Stamina.CanRegenerate = true;
        }
        private void TransitionToInAir()
        {
            _context.StateMachine.StateMachine.SwitchState(_context.StateMachine.inAirState);
        }
    }
}