using UnityEngine;

namespace TheCreators.Player
{
    [CreateAssetMenu(fileName = "RunState", menuName = "PlayerStates/Run")]
    public class NewRunState : NewPlayerState
    {
        public float _speed = 6f;
        public override void Enter()
        {
            _context.Animator.SetBool("Run", true);
        }
        public override void LogicUpdate()
        {
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
            _context.Animator.SetBool("Run", false);
        }
    }
}
