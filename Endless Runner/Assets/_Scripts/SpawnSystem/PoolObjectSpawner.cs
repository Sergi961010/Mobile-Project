using TheCreators.PoolingSystem;
using UnityEngine;

namespace TheCreators.SpawnSystem
{
    public class PoolObjectSpawner<T> where T : PoolEntity
    {
        readonly IPoolableEntityFactory<T> entityFactory;
        ISpawnPointStrategy spawnPointStrategy;
        public PoolObjectSpawner(IPoolableEntityFactory<T> entityFactory)
        {
            this.entityFactory = entityFactory;
        }
        public PoolObjectSpawner(IPoolableEntityFactory<T> entityFactory, ISpawnPointStrategy spawnPointStrategy)
        {
            this.entityFactory = entityFactory;
            this.spawnPointStrategy = spawnPointStrategy;
        }
        public T Spawn()
        {
            return entityFactory.Create(spawnPointStrategy.NextSpawnPoint());
        }
        public void SetSpawnPointStrategy(ISpawnPointStrategy spawnPointStrategy)
        {
            this.spawnPointStrategy = spawnPointStrategy;
        }
    }
}