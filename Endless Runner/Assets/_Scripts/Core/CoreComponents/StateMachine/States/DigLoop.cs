using TheCreators.Managers;
using UnityEngine;

namespace TheCreators.Player.StateMachine.States
{
    [CreateAssetMenu(fileName = "DigLoopState", menuName = "PlayerStates/Dig/DigLoop")]
    public class DigLoop : PlayerState
    {
        public float staminaCost = 20f;
        public override void Enter()
        {
            _context.PlayerAnimator.PlayLockedAnimation(animations[0]);
            SoundManager.Instance.PlayLoopedAudioEvent(audioEvent);
        }
        public override void Exit()
        {
            SoundManager.Instance.StopLoopedAudioEvent();
        }
        public override void LogicUpdate()
        {
            _context.Stamina.SubstractStamina(staminaCost);
            if (_context.InputController.CanUnburrow || _context.Stamina.CurrentStamina == 0) 
                TransitionToDigExit();
        }
        public override void PhysicsUpdate()
        {
        }
        private void TransitionToDigExit()
        {
            _context.StateMachine.StateMachine.SwitchState(_context.StateMachine.digExitState);
        }
    }
}