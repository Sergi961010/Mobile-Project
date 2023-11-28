using TheCreators.PoolingSystem;
using UnityEngine;

namespace TheCreators.SpawnSystem
{
    public class PoolObjectSpawner<T> where T : PoolEntity
    {
        readonly IPoolableEntityFactory<T> entityFactory;
        readonly ISpawnPointStrategy spawnPointStrategy;
        public PoolObjectSpawner(IPoolableEntityFactory<T> entityFactory, ISpawnPointStrategy spawnPointStrategy)
        {
            this.entityFactory = entityFactory;
            this.spawnPointStrategy = spawnPointStrategy;
        }
        public T Spawn()
        {
            return entityFactory.Create(spawnPointStrategy.NextSpawnPoint());
        }
    }
}