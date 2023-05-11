using System.Collections.Generic;
using TheCreators.ScriptableObjects;
using UnityEngine;

namespace TheCreators.Managers
{
    public class PoolsManager : MonoBehaviour
    {
        #region Singleton
        private static PoolsManager _instance;

        public static PoolsManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<PoolsManager>();
                }
                return _instance;
            }
        }
        #endregion

        [SerializeField] private List<Pool> pools;
        private Dictionary<string, Queue<GameObject>> _poolDictionary;

        private void Awake()
        {
            _poolDictionary = new Dictionary<string, Queue<GameObject>>();

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
            foreach (Pool pool in pools)
            {
                Queue<GameObject> objectPool = new Queue<GameObject>();

                for (int i = 0; i < pool.size; i++)
                {
                    GameObject go = Instantiate(pool.prefab);
                    go.SetActive(false);
                    objectPool.Enqueue(go);
                }

                _poolDictionary.Add(pool.tag, objectPool);
            }
        }

        public GameObject SpawnFromPool(string tag, Vector2 position, Quaternion rotation)
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
