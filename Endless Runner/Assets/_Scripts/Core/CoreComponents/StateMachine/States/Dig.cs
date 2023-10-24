using TheCreators.CustomEventSystem;
using TheCreators.Managers;
using UnityEngine;

namespace TheCreators.Player.StateMachine.States
{
    [CreateAssetMenu(fileName = "DigState", menuName = "PlayerStates/Dig")]
    public class Dig : PlayerState
    {
        public float undergroundYPosition = -3.2f;
        public float surfaceYPosition = -2f;
        public float duration = .5f;
        public float elapsedTime;
        public float staminaCost = 5f;
        public override void Enter()
        {
            _context.PlayerAnimator.PlayLockedAnimation(_animations[0]);
            _context.SpriteRenderer.ChangeSortingOrder(2);
            //_context.EnergyBarController.StaminaAbilityStart(staminaCost);
            SoundManager.Instance.PlayLoopedSound(_audioClip);
            _context.Movement.Burrow(duration, surfaceYPosition, undergroundYPosition);
        }
        public override void Exit()
        {
            //_context.SpriteRenderer.ChangeSortingOrder(0);
            //_context.EnergyBarController.StaminaAbilityEnd();
            SoundManager.Instance.StopLoopedSound();
        }
        public override void LogicUpdate()
        {
            _context.PlayerAnimator.PlayAnimation(_animations[1]);
            if (_context.InputController.CanUnburrow) TransitionToRun();
        }
        public override void PhysicsUpdate()
        {
        }
        private void TransitionToRun()
        {
            _context.PlayerAnimator.PlayLockedAnimation(_animations[2]);
            _context.Movement.Unburrow(duration, undergroundYPosition, surfaceYPosition);
            _context.StateMachine.StateMachine.SwitchState(_context.StateMachine.runState);
        }
    }
}