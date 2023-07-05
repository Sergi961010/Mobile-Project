using System;
using System.Collections;
using UnityEngine;

namespace TheCreators.Player
{
    public class DigState : State
    {
        private readonly float _undergroundYPosition = -3.2f;
        private readonly float _surfaceYPosition = -2f;
        private readonly float duration = .5f;
        private float elapsedTime;
        private bool burrow;
        public DigState(Player currentContext) : base(currentContext) { }
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
                _context.StateMachine.SwitchState(_context.StateFactory.Run());
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