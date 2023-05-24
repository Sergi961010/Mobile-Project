using TheCreators.ScriptableObjects;
using TheCreators.Enums;
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
        private Dictionary<PoolType, List<GameObject>> _poolDictionary;

        private void Awake()
        {
            _poolDictionary = new Dictionary<PoolType, List<GameObject>>();

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
                List<GameObject> objectPool = new();
                GameObject parent = new(pool.poolType.ToString());
                parent.transform.parent = transform;

                for (int i = 0; i < pool.levelParts.Count; i++)
                {
                    for (int j = 0; j < pool.levelPartAmount; j++)
                    {
                        GameObject go = Instantiate(pool.levelParts[i].prefab);
                        go.SetActive(false);
                        go.transform.parent = parent.transform;
                        objectPool.Add(go);
                    }
                }

                _poolDictionary.Add(pool.poolType, objectPool);
            }
        }

        public GameObject RequestLevelPart(PoolType poolType)
        {
            if (!_poolDictionary.ContainsKey(poolType))
            {
                Debug.LogWarning("Pool with tag: " + tag + " doesn't exist");
                return null;
            }

            GameObject objectToSpawn = GetRandomlevelPart(_poolDictionary[poolType], poolType);

            return objectToSpawn;
        }

        private GameObject GetRandomlevelPart(List<GameObject> gameObjects, PoolType poolType)
        {
            string roll = GetRandomPlatformName(poolType);
            List<GameObject> selected = gameObjects.FindAll(x => x.name.Equals(roll));

            for (int i = 0; i < selected.Count; i++)
            {
                if (!selected[i].activeInHierarchy)
                {
                    selected[i].SetActive(true);
                    return selected[i];
                }
            }

            Debug.LogWarning("Platform: " + roll + " doesn't exist");
            return null;
        }

        private string GetRandomPlatformName(PoolType poolType)
        {
            int max = _pools[(int)poolType].levelParts.Count;
            int random = Random.Range(0, max);
            string roll = _pools[(int)poolType].levelParts[random].tag.ToString() + "(Clone)";
            return roll;
        }
    }
}
