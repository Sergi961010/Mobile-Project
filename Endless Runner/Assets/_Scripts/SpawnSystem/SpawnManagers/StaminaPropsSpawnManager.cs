using System.Collections.Generic;
using UnityEngine;

namespace TheCreators.SpawnSystem
{
    public class StaminaPropsSpawnManager : EntitySpawnManager
    {
        [SerializeField] StaminaCollectibleData[] staminaCollectibleData;
        [SerializeField] int maxSpawns = 2;
        PoolObjectSpawner<PoolObject> spawner;
        private void OnEnable()
        {
            spawnPoints = GetSpawnPoints();
            spawnPointStrategy = new RandomSpawnPointStrategy(spawnPoints);
            spawner = new PoolObjectSpawner<PoolObject>(
                new PoolObjectFactory<PoolObject>(staminaCollectibleData),
                spawnPointStrategy);
            int index = Random.Range(0, maxSpawns);
            for (int i = 0; i < index; i++)
            {
                Spawn();
            }
        }
        public override void Spawn() => spawner.Spawn();
        private Transform[] GetSpawnPoints()
        {
            List<Transform> spawnPointsTransforms = new(gameObject.GetComponentsInChildren<Transform>());
            spawnPointsTransforms.RemoveAt(0);
            return spawnPointsTransforms.ToArray();
        }
    }
}