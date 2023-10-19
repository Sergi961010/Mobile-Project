using System;
using TheCreators.CustomEventSystem;
using TheCreators.Managers;
using UnityEngine;

namespace TheCreators.Player.StateMachine.States
{
    [CreateAssetMenu(fileName = "FlyState", menuName = "PlayerStates/Fly")]
    public class Fly : PlayerState
    {
        public float defaultForce = 20f;
        public float smoothFactor = .2f;
        public float staminaCost = .5f;
        public override void Enter()
        {
            _context.Movement.ModifyGravity(smoothFactor);
            _context.Movement.ModifyYVelocity(smoothFactor);
            _context.PlayerAnimator.PlayLockedAnimation(_animations[0]);
            //_context.EnergyBarController.StaminaAbilityStart(staminaCost);
            SoundManager.Instance.PlayLoopedSound(_audioClip);
            GameEvent.OnCancelFly.AddListener(TransitionToInAir);
        }
        public override void LogicUpdate()
        {
            _context.PlayerAnimator.PlayAnimation(_animations[1]);
        }
        public override void PhysicsUpdate()
        {
            _context.Movement.Fly(defaultForce);
        }
        public override void Exit()
        {
            _context.PlayerAnimator.PlayAnimation(_animations[2]);
            _context.Movement.ResetGravityScale();
            //_context.EnergyBarController.StaminaAbilityEnd();
            SoundManager.Instance.StopLoopedSound();
            GameEvent.OnCancelFly.RemoveListener(TransitionToInAir);
        }
        private void TransitionToInAir()
        {
            _context.StateMachine.StateMachine.SwitchState(_context.StateMachine.inAirState);
        }
    }
}