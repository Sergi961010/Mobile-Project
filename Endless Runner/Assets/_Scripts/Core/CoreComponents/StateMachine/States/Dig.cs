using TheCreators.CustomEventSystem;
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
        public float staminaCost = 20f;
        public override void Enter()
        {
            _context.PlayerAnimator.PlayLockedAnimation(animations[0]);
            _context.SpriteRenderer.ChangeSortingOrder(2);
            _context.AudioController.PlayLoopedAudioEvent(audioEvent);
            _context.Movement.Burrow(duration, surfaceYPosition, undergroundYPosition);
            _context.Stamina.CanRegenerate = false;
        }
        public override void Exit()
        {
            //_context.SpriteRenderer.ChangeSortingOrder(0);
            _context.AudioController.StopLoopedAudioEvent();
            _context.Stamina.CanRegenerate = true;
        }
        public override void LogicUpdate()
        {
            _context.PlayerAnimator.PlayAnimation(animations[1]);
            _context.Stamina.SubstractStamina(staminaCost);
            if (_context.InputController.CanUnburrow || _context.Stamina.CurrentStamina == 0) 
                TransitionToRun();
        }
        public override void PhysicsUpdate()
        {
        }
        private void TransitionToRun()
        {
            _context.PlayerAnimator.PlayLockedAnimation(animations[2]);
            _context.Movement.Unburrow(duration, undergroundYPosition, surfaceYPosition);
            _context.StateMachine.StateMachine.SwitchState(_context.StateMachine.runState);
        }
    }
}