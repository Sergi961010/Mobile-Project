using UnityEngine;
using UnityEngine.Events;

namespace TheCreators.CustomEventSystem
{
    public class GameEventListener : MonoBehaviour
    {
        [Tooltip("Event to register with.")]
        public NewGameEvent Event;
        [Tooltip("Response to invoke when Event is raised.")]
        public UnityEvent Response;
        private void OnEnable()
        {
            Event.RegisterListener(this);
        }
        private void OnDisable()
        {
            Event.UnregisterListener(this);
        }
        public void OnEventRaised()
        {
            Response.Invoke();
        }
    }
}