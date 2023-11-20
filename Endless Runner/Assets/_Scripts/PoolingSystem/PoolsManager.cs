using System;
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
        private readonly Dictionary<string, Queue<GameObject>> _objectPool = new();
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
        public GameObject GetObject(GameObject objectToSpawn)
        {
            if (_objectPool.TryGetValue(objectToSpawn.name, out Queue<GameObject> objectList))
            {
                if (objectList.Count == 0)
                    return CreateNewObject(objectToSpawn);
                else
                {
                    GameObject returnObject = objectList.Dequeue();
                    returnObject.SetActive(true);
                    return returnObject;
                }
            }
            else
                return CreateNewObject(objectToSpawn);
        }
        public void ReturnObjectToPool(GameObject gameObject)
        {
            if (_objectPool.TryGetValue(gameObject.name, out Queue<GameObject> objectList))
                objectList.Enqueue(gameObject);
            else
            {
                CreateNewPool(gameObject);
            }
            gameObject.SetActive(false);
        }
        private GameObject CreateNewObject(GameObject gameObject)
        {
            GameObject go = Instantiate(gameObject);
            go.name = gameObject.name;
            return go;
        }
        private void CreateNewPool(GameObject gameObject)
        {
            Queue<GameObject> newObjectQueue = new();
            newObjectQueue.Enqueue(gameObject);
            _objectPool.Add(gameObject.name, newObjectQueue);
        }
    }
}