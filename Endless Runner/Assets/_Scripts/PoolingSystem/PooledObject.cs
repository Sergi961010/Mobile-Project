using UnityEngine;

namespace TheCreators.PoolingSystem
{
    [RequireComponent(typeof(Collider2D))]
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
                _poolsManager.ReturnObjectToPool(gameObject);
        }
        private void OnValidate()
        {
            BoxCollider2D collider = GetComponent<BoxCollider2D>();
            if (collider == null) collider = gameObject.AddComponent<BoxCollider2D>();

            collider.isTrigger = true;
        }
    }
}