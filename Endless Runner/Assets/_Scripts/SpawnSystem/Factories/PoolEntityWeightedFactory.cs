using System.Collections.Generic;
using TheCreators.PoolingSystem;
using UnityEngine;

namespace TheCreators.SpawnSystem
{
    public class PoolEntityWeightedFactory<T> : IPoolableEntityFactory<T> where T : PoolEntity
    {
        readonly EntityData[] data;
        readonly Dictionary<string, ObjectPool<PoolEntity>> _objectPools = new();
        public PoolEntityWeightedFactory(EntityData[] data)
        {
            this.data = data;
            InitPools();
        }
        public T Create(Transform spawnPoint)
        {
            System.Random random = new();
            double accumulatedWeights = CalculateAccumulatedWeights();
            double roll = random.NextDouble() * accumulatedWeights;
            double currentWeight = data[0].chance;
            for (int i = 0; i < data.Length; i++)
            {
                if (currentWeight >= roll)
                    return _objectPools[data[i].prefab.name].PullGameObject(spawnPoint.position).GetComponent<T>();
                currentWeight += data[i].chance;
            }
            return _objectPools[data[0].prefab.name].PullGameObject(spawnPoint.position).GetComponent<T>();
        }
        double CalculateAccumulatedWeights()
        {
            double result = 0;
            foreach (var item in data)
            {
                result += item.chance;
            }
            return result;
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