using TheCreators.Managers;
using UnityEngine;

namespace TheCreators.Player
{
    [CreateAssetMenu(fileName = "RunState", menuName = "PlayerStates/Run")]
    public class NewRunState : NewPlayerState
    {
        public float _speed = 6f;
        public override void Enter()
        {
            _context.InputManager.JumpAction.Enable();
            _context.InputManager.PrimaryTouch.Enable();
        }
        public override void LogicUpdate()
        {
            _context.PlayerAnimator.PlayAnimation(_animations[0]);
            if (_context.InputManager.JumpPerformed)
            {
                _context.StateMachine.SwitchState(_context.jumpState);
                _context.InputManager.UseJumpInput();
            }
            if (_context.InputManager.SwipeDetection.BurrowPerformed)
            {
                _context.StateMachine.SwitchState(_context.digState);
            }
        }
        public override void PhysicsUpdate()
        {
            _context.RB.velocity = new Vector2(_speed, 0);
        }
        public override void Exit()
        {
            //SoundManager.Instance.StopLoopedSound();
        }
    }
}
