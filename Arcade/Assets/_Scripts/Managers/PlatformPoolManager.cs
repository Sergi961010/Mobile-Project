using TheCreators.ScriptableObjects;
using TheCreators.Enums.Platforms;
using System.Collections.Generic;
using UnityEngine;

namespace TheCreators.Managers
{
    public class PlatformPoolManager : MonoBehaviour
    {
        #region Singleton
        private static PlatformPoolManager _instance;

        public static PlatformPoolManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<PlatformPoolManager>();
                }
                return _instance;
            }
        }
        #endregion

        [SerializeField] private List<Pool> _pools;
        private Dictionary<Tag, Queue<GameObject>> _poolDictionary;

        private void Awake()
        {
            _poolDictionary = new Dictionary<Tag, Queue<GameObject>>();

            #region Singleton
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
            }
            #endregion
        }
        private void Start()
        {
            FillPools();
        }

        private void FillPools()
        {
            foreach (Pool pool in _pools)
            {
                Queue<GameObject> objectPool = new();

                for (int i = 0; i < pool.size; i++)
                {
                    GameObject go = Instantiate(pool.platform.prefab);
                    go.SetActive(false);
                    objectPool.Enqueue(go);
                    go.transform.parent = transform;
                }

                _poolDictionary.Add(pool.platform.tag, objectPool);
            }
        }

        public GameObject GetPooledObject(Tag tag, Vector2 position, Quaternion rotation)
        {
            if(!_poolDictionary.ContainsKey(tag))
            {
                return null;
            }

            GameObject objectToSpawn = _poolDictionary[tag].Dequeue();

            objectToSpawn.SetActive(true);
            objectToSpawn.transform.SetPositionAndRotation(position, rotation);

            _poolDictionary[tag].Enqueue(objectToSpawn);

            return objectToSpawn;
        }
    }
}
