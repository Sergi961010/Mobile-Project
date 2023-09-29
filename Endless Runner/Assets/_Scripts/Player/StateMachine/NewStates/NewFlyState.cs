using TheCreators.Managers;
using UnityEngine;

namespace TheCreators.Player
{
    [CreateAssetMenu(fileName = "FlyState", menuName = "PlayerStates/Fly")]
    public class NewFlyState : NewPlayerState
    {
        public float defaultForce = 20f;
        public float smoothFactor = .2f;
        public float staminaCost = .5f;
        public override void Enter()
        {
            ApplyGravityMultiplier();
            HandleYVelocity();
            _context.PlayerAnimator.PlayLockedAnimation(_animations[0]);
            _context.EnergyBarController.StaminaAbilityStart(staminaCost);
            SoundManager.Instance.PlayLoopedSound(_audioClip);
        }
        public override void LogicUpdate()
        {
            _context.PlayerAnimator.PlayAnimation(_animations[1]);
            if (!_context.InputManager.FlyPerformed)
            {
                _context.StateMachine.SwitchState(_context.fallState);
            }
        }
        public override void Exit()
        {
            _context.PlayerAnimator.PlayAnimation(_animations[2]);
            CancelGravityMultiplier();
            _context.EnergyBarController.StaminaAbilityEnd();
            SoundManager.Instance.StopLoopedSound();
        }
        public override void PhysicsUpdate()
        {
            HandleFly();
        }
        private void HandleFly()
        {
            _context.RB.AddForce(Vector2.up * defaultForce, ForceMode2D.Force);
        }
        private void ApplyGravityMultiplier()
        {
            _context.RB.gravityScale *= smoothFactor;
        }
        private void CancelGravityMultiplier()
        {
            _context.RB.gravityScale /= smoothFactor;
        }
        private void HandleYVelocity()
        {
            _context.RB.velocity = new Vector2(_context.RB.velocity.x, _context.RB.velocity.y * smoothFactor);
        }
    }
}