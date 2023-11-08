using UnityEngine;

namespace TheCreators.CoreSystem.CoreComponents
{
    public class BaseCoreComponent : MonoBehaviour
    {
        protected Core Core;

        protected virtual void Awake()
        {
            Core = GetComponentInParent<Core>();
        }
    }
}