using TheCreators.PoolingSystem;
using UnityEngine;

namespace TheCreators.SpawnSystem
{
    public interface IEntityFactory<T> where T : PoolObject
    {
        T Create(Transform spawnPoint);
    }
}