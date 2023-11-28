using System.Collections.Generic;
using TheCreators.PoolingSystem;
using UnityEngine;

namespace TheCreators.SpawnSystem
{
    public class PoolEntityFactory<T> : IPoolableEntityFactory<T> where T : PoolEntity
    {
        readonly EntityData[] data;
        readonly Dictionary<string, ObjectPool<PoolEntity>> _objectPools = new();
        public PoolEntityFactory(EntityData[] data)
        {
            this.data = data;
            InitPools();
        }
        public T Create(Transform spawnPoint)
        {
            EntityData entityData = data[Random.Range(0, data.Length)];
            GameObject instance = _objectPools[entityData.prefab.name].PullGameObject(spawnPoint.position);
            return instance.GetComponent<T>();
        }
        void InitPools()
        {
            foreach (var item in data)
            {
                _objectPools.Add(item.prefab.name, new ObjectPool<PoolEntity>(item.prefab));
            }
        }
    }
}