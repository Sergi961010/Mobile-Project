using TheCreators.Utilities;
using UnityEngine;

namespace TheCreators.Player.StateMachine.States
{
    [CreateAssetMenu(fileName = "DigExitState", menuName = "PlayerStates/Dig/DigExit")]
    public class DigExit : PlayerState
    {
        public float startYPosition = -3.4f;
        public float endYPosition = -2;
        private float _stateDuration;
        public override void Enter()
        {
            _stateDuration = animations[0].length;
            _context.PlayerAnimator.PlayAnimation(animations[0]);
            _context.AudioController.PlayAudioEvent(audioEvent);
        }
        public override void Exit()
        {
            _context.Movement.Rigidbody.isKinematic = false;
            _context.Stamina.CanRegenerate = true;
            _context.SpriteRenderer.ChangeSortingOrder(0);
        }
        public override void LogicUpdate()
        {
            _stateDuration -= Time.deltaTime;
            if (_stateDuration <= 0)
                TransitionToRun();
        }
        public override void PhysicsUpdate()
        {
            _context.Movement.HandleDigTranslation(endYPosition);
        }
        private void TransitionToRun()
        {
            _context.StateMachine.StateMachine.SwitchState(_context.StateMachine.runState);
        }
    }
}
