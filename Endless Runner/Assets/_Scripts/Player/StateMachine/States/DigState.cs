using System;
using System.Collections;
using UnityEngine;

namespace TheCreators.Player.StateMachine
{
    public class DigState : State
    {
        private readonly float _undergroundYPosition = -3.15f;
        private readonly float _surfaceYPosition = -2.06f;
        private readonly float duration = 1f;
        private float elapsedTime;
        private bool burrow;
        private bool unburrow;
        public DigState(StateMachine currentContext, StateFactory stateFactory) : base(currentContext, stateFactory) { }
        public override void Enter()
        {
            Debug.Log("Enter Dig");
            burrow = true;
        }
        private void HandleBurrow()
        {
            Vector2 newPosition = _context.transform.position;
            float percentageComplete = elapsedTime / duration;
            elapsedTime += Time.deltaTime;
            newPosition.x = _context.transform.position.x + _context.RunData.Speed * Time.deltaTime;
            newPosition.y = Mathf.Lerp(_surfaceYPosition, _undergroundYPosition, percentageComplete);
            _context.Rigidbody.isKinematic = true;
            _context.Rigidbody.MovePosition(newPosition);

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
            newPosition.x = _context.transform.position.x + _context.RunData.Speed * Time.deltaTime;
            newPosition.y = Mathf.Lerp(_undergroundYPosition, _surfaceYPosition, percentageComplete);
            _context.Rigidbody.MovePosition(newPosition);

            if (elapsedTime >= duration)
            {
                _context.Rigidbody.isKinematic = false;
                elapsedTime = 0;
                _context.InputManager.SwipeDetection.UseUnburrow();
                SwitchState(_stateFactory.Run());
            }
        }
        public override void LogicUpdate()
        {
            //CheckSwitchState();
        }
        public override void ExitState()
        {
            
        }
        public override void CheckSwitchState()
        {
            if (_context.InputManager.SwipeDetection.UnburrowPerformed)
            {
                SwitchState(_stateFactory.Run());
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