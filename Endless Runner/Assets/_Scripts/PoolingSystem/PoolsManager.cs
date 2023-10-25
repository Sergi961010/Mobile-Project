using System.Collections.Generic;
using UnityEngine;

namespace TheCreators.PoolingSystem
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
        private readonly Dictionary<string, Queue<GameObject>> _poolDictionary = new();
        private void Awake()
        {
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
        public GameObject GetObject(GameObject gameObject)
        {
            if (_poolDictionary.TryGetValue(gameObject.name, out Queue<GameObject> objectList))
            {
                if (objectList.Count == 0)
                    return CreateNewObject(gameObject);
                else
                {
                    GameObject go = objectList.Dequeue();
                    go.SetActive(true);
                    return go;
                }
            }
            else
                return CreateNewObject(gameObject);
        }
        private GameObject CreateNewObject(GameObject gameObject)
        {
            GameObject go = Instantiate(gameObject);
            go.name = gameObject.name;
            return go;
        }
        public void ReturnGameObject(GameObject gameObject)
        {
            if (_poolDictionary.TryGetValue(gameObject.name, out Queue<GameObject> objectList))
                objectList.Enqueue(gameObject);
            else
            {
                Queue<GameObject> newObjectQueue = new();
                newObjectQueue.Enqueue(gameObject);
                _poolDictionary.Add(gameObject.name, newObjectQueue);
            }
            gameObject.SetActive(false);
        }
    }
}