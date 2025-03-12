using UnityEngine;

namespace TheCreators.SpawnSystem
{
    public class SimpleSpawnPointStrategy : ISpawnPointStrategy
    {
        readonly Transform spawnPoint;
        public SimpleSpawnPointStrategy(Transform spawnPoint) => this.spawnPoint = spawnPoint;
        public Transform NextSpawnPoint() => spawnPoint;
    }
}