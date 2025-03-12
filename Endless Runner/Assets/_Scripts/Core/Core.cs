using System.Collections.Generic;
using System.Linq;
using TheCreators.CoreSystem.CoreComponents;
using UnityEngine;

namespace TheCreators.CoreSystem
{
    public class Core : MonoBehaviour
    {
        private readonly List<CoreComponent> _coreComponents = new();
        public void AddComponent(CoreComponent component)
        {
            if (!_coreComponents.Contains(component))
            {
                _coreComponents.Add(component);
            }
        }
        public T GetCoreComponent<T>() where T : CoreComponent
        {
            var component = _coreComponents.OfType<T>().FirstOrDefault();
            if (component == null)
                Debug.LogWarning($"{typeof(T)} not found on {transform.parent.name}");
            return component;
        }
    }
}
