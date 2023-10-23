using System;
using TheCreators.CustomEventSystem;
using UnityEngine;

namespace TheCreators.Input
{
    public class SwipeDetection : MonoBehaviour
    {
        [SerializeField] private float _minimumDistance = .2f;
        [SerializeField] private float _maximumTime = 1f;
        [SerializeField, Range(0f, 1f)] private float _directionThreshold = .9f;

        private Vector2 _startPosition, _endPosition;
        private float _startTime, _endTime;

        private void OnEnable()
        {
            GameEvent.StartTouch.AddListener(SwipeStart);
            GameEvent.EndTouch.AddListener(SwipeEnd);
        }
        private void SwipeStart(Vector2 position, float time)
        {
            _startPosition = position;
            _startTime = time;
        }
        private void SwipeEnd(Vector2 position, float time)
        {
            _endPosition = position;
            _endTime = time;
            DetectSwipe();
        }
        private void DetectSwipe()
        {
            if (Vector2.Distance(_startPosition, _endPosition) >= _minimumDistance && (_endTime - _startTime) <= _maximumTime)
            {
                Vector2 direction = _endPosition - _startPosition;
                SwipeDirection(direction.normalized);
            }
        }
        private void SwipeDirection(Vector2 direction)
        {
            if(Vector2.Dot(Vector2.down, direction) > _directionThreshold)
            {
                GameEvent.OnPerformBurrow.Invoke();
            }
            if (Vector2.Dot(Vector2.up, direction) > _directionThreshold)
            {
                GameEvent.OnPerformUnburrow.Invoke();
            }
        }
    }
}