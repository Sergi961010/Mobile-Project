using UnityEngine;

namespace TheCreators.CoreSystem.CoreComponents
{
    public class CoreComponent : MonoBehaviour
    {
        protected Core Core;

        protected virtual void Awake()
        {
            Core = GetComponentInParent<Core>();
            Core.AddComponent(this);
        }
    }
}