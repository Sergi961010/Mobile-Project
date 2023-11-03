using System.Collections.Generic;
using UnityEngine;

namespace TheCreators.CustomEventSystem
{
    [CreateAssetMenu]
    public class NewGameEvent : ScriptableObject
    {
        private readonly List<GameEventListener> eventListeners = new();
        public void Raise()
        {
            for (int i = eventListeners.Count - 1; i >= 0; i--)
                eventListeners[i].OnEventRaised();
        }
        public void RegisterListener(GameEventListener listener)
        {
            if (!eventListeners.Contains(listener))
                eventListeners.Add(listener);
        }
        public void UnregisterListener(GameEventListener listener)
        {
            if (eventListeners.Contains(listener))
                eventListeners.Remove(listener);
        }
    }
}