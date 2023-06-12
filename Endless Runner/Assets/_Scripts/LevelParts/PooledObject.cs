using TheCreators.Managers;
using UnityEngine;

namespace TheCreators
{
    public class PooledObject : MonoBehaviour
    {
        private PoolsManager _poolsManager;

        private void Start()
        {
            _poolsManager = FindObjectOfType<PoolsManager>();
        }

        private void OnDisable()
        {
            if (_poolsManager != null)
                _poolsManager.ReturnGameObject(gameObject);
        }
    }
}
