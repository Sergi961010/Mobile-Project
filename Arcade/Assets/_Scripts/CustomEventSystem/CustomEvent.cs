using System;
using UnityEngine;

namespace TheCreators.CustomEventSystem
{
    public class CustomEvent
    {
        private event Action Action = delegate { };

        public void Invoke()
        {
            Action.Invoke();
        }

        public void AddListener(Action listener)
        {
            Action += listener;
        }

        public void RemoveListener(Action listener)
        {
            Action -= listener;
        }
    }

    public class CustomEvent<T>
    {
        private event Action<T> Action = delegate { };

        public void Invoke(T param)
        {
            Action.Invoke(param);
        }

        public void AddListener(Action<T> listener)
        {
            Action += listener;
        }

        public void RemoveListener(Action<T> listener)
        {
            Action -= listener;
        }
    }

    public class CustomEvent<T, H>
    {
        private event Action<T, H> Action = delegate { };

        public void Invoke(T param, H param2)
        {
            Action.Invoke(param, param2);
        }

        public void AddListener(Action<T, H> listener)
        {
            Action += listener;
        }

        public void RemoveListener(Action<T, H> listener)
        {
            Action -= listener;
        }
    }
}
