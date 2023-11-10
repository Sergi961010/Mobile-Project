using TheCreators.Utilities;
using UnityEngine;
using UnityEngine.Events;

namespace TheCreators.UI
{
	public class TimeSlider : BaseSlider
	{
        [SerializeField] private float time = 3f;
        [SerializeField] private UnityEvent timerEndEvent;
        private CountdownTimer _timer;
        private void Awake()
        {
            _timer = new CountdownTimer(time);
            _timer.OnTimerStop += () => timerEndEvent.Invoke();
        }
        private void OnEnable()
        {
            _timer.Start();
        }
        private void Update()
        {
            _timer.Tick(Time.deltaTime);
            FillBar(_timer.Progress);
        }
    }
}