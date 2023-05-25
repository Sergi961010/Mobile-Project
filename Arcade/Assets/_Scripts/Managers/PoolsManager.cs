using TheCreators.ScriptableObjects;
using System.Collections.Generic;
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

        [SerializeField] private Transform _poolsContainer;
        [SerializeField] private List<PoolInfo> _poolsInfo;
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
            foreach (PoolInfo poolInfo in _poolsInfo)
            {
                FillPool(poolInfo);
            }
        }

        private void FillPool(PoolInfo poolInfo)
        {
            GameObject poolContainer = new(poolInfo.containerName);
            Queue<GameObject> objectPool = new();

            poolContainer.transform.SetParent(_poolsContainer);

            for (int i = 0; i < poolInfo.size; i++)
            {
                GameObject go = Instantiate(poolInfo.prefab, poolContainer.transform);
                go.SetActive(false);
                objectPool.Enqueue(go);
            }

            _poolDictionary.Add(poolInfo.poolType, objectPool);
        }

        public GameObject GetObjectFromPool(string poolType)
        {
            if (!_poolDictionary.ContainsKey(poolType))
            {
                Debug.LogWarning("Pool with tag: " + tag + " doesn't exist");
                return null;
            }

            GameObject objectToSpawn = _poolDictionary[poolType].Dequeue();
            _poolDictionary[poolType].Enqueue(objectToSpawn);

            return objectToSpawn;
        }
    }
}
