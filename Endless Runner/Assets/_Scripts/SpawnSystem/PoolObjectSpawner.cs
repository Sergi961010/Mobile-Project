using UnityEngine;

namespace TheCreators.SpawnSystem
{
    public class PoolObjectSpawner<T> where T : PoolObject
    {
        readonly IEntityFactory<T> entityFactory;
        readonly ISpawnPointStrategy spawnPointStrategy;
        public PoolObjectSpawner(IEntityFactory<T> entityFactory, ISpawnPointStrategy spawnPointStrategy)
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