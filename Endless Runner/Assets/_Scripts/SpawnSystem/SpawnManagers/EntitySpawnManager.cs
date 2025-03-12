using UnityEngine;

namespace TheCreators.SpawnSystem
{
    public abstract class EntitySpawnManager : MonoBehaviour
    {
        [SerializeField] protected SpawnPointStrategyType spawnPointStrategyType = SpawnPointStrategyType.Simple;
        [SerializeField] protected Transform[] spawnPoints;
        protected ISpawnPointStrategy spawnPointStrategy;
        protected enum SpawnPointStrategyType
        {
            Simple,
            Random,
            Default
        }
        protected virtual void Awake()
        {
            spawnPointStrategy = spawnPointStrategyType switch
            {
                SpawnPointStrategyType.Simple => new SimpleSpawnPointStrategy(spawnPoints[0]),
                SpawnPointStrategyType.Random => new RandomSpawnPointStrategy(spawnPoints),
                _ => spawnPointStrategy
            };
        }
        public abstract void Spawn();
    }
}