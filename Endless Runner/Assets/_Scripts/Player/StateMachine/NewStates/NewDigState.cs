using UnityEngine;

namespace TheCreators.Player
{
    [CreateAssetMenu(fileName = "DigState", menuName = "PlayerStates/Dig")]
    public class NewDigState : NewPlayerState
    {
        public float _undergroundYPosition = -3.2f;
        public float _surfaceYPosition = -2f;
        public float duration = .5f;
        public float elapsedTime;
        public bool burrow;
        public override void Enter()
        {
            burrow = true;
        }
        private void HandleBurrow()
        {
            Vector2 newPosition = _context.transform.position;
            float percentageComplete = elapsedTime / duration;
            elapsedTime += Time.deltaTime;
            newPosition.x = _context.transform.position.x + _context.RB.velocity.x * Time.deltaTime;
            newPosition.y = Mathf.Lerp(_surfaceYPosition, _undergroundYPosition, percentageComplete);
            _context.RB.isKinematic = true;
            _context.RB.MovePosition(newPosition);

            if (elapsedTime >= duration)
            {
                elapsedTime = 0;
                burrow = false;
            }
        }
        private void HandleUnburrow()
        {
            Vector2 newPosition = _context.transform.position;
            float percentageComplete = elapsedTime / duration;
            elapsedTime += Time.deltaTime;
            newPosition.x = _context.transform.position.x + _context.RB.velocity.x * Time.deltaTime;
            newPosition.y = Mathf.Lerp(_undergroundYPosition, _surfaceYPosition, percentageComplete);
            _context.RB.MovePosition(newPosition);

            if (elapsedTime >= duration)
            {
                _context.RB.isKinematic = false;
                elapsedTime = 0;
                _context.StateMachine.SwitchState(_context.runState);
            }
        }
        public override void PhysicsUpdate()
        {
            if (burrow)
                HandleBurrow();
            if (_context.InputManager.SwipeDetection.UnburrowPerformed)
            {
                HandleUnburrow();
            }
        }
    }
}