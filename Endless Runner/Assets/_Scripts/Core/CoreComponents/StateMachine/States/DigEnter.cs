using TheCreators.Utilities;
using UnityEngine;

namespace TheCreators.Player.StateMachine.States
{
    [CreateAssetMenu(fileName = "DigEnterState", menuName = "PlayerStates/Dig/DigEnter")]
    public class DigEnter : PlayerState
    {
        public float startYPosition = -2f;
        public float endYPosition = -3.4f;
        private float _stateDuration;
        public override void Enter()
        {
            _stateDuration = animations[0].length;
            _context.Movement.Rigidbody.isKinematic = true;
            _context.PlayerAnimator.PlayAnimation(animations[0]);
            _context.SpriteRenderer.ChangeSortingOrder(2);
            _context.AudioController.PlayAudioEvent(audioEvent);
            _context.Stamina.CanRegenerate = false;
            _context.Movement.StartHandleDigTranslationCoroutine(animations[0].length, startYPosition, endYPosition);
        }
        public override void Exit()
        {
            
        }
        public override void LogicUpdate()
        {
            _stateDuration -= Time.deltaTime;
            if (_stateDuration <= 0)
                TransitionToDigLoop();
        }
        public override void PhysicsUpdate()
        {
            
        }
        private void TransitionToDigLoop()
        {
            _context.StateMachine.StateMachine.SwitchState(_context.StateMachine.digLoopState);
        }
    }
}
