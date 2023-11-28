using TheCreators.PoolingSystem;
using UnityEngine;

namespace TheCreators.SpawnSystem
{
    public interface IPoolableEntityFactory<T> where T : PoolEntity
    {
        T Create(Transform spawnPoint);
    }
}