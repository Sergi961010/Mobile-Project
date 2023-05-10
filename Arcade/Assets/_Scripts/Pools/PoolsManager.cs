using System.Collections.Generic;
using TheCreators.ScriptableObjects;
using UnityEngine;

namespace TheCreators.Pools
{
    public class PoolsManager : MonoBehaviour
    {
        [SerializeField] private List<Pool> pools;
        private Dictionary<string, Queue<GameObject>> _poolDictionary;

        private void Awake()
        {
            _poolDictionary = new Dictionary<string, Queue<GameObject>>();
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
    }
}
