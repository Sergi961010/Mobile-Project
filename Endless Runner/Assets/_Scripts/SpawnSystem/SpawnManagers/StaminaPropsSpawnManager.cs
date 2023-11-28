using System.Collections.Generic;
using TheCreators.CustomEventSystem;
using TheCreators.PoolingSystem;
using UnityEngine;

namespace TheCreators.SpawnSystem
{
    public class StaminaPropsSpawnManager : MonoBehaviour
    {
        [SerializeField] StaminaCollectibleData[] staminaCollectibleData;
        [SerializeField] int maxSpawns = 2;
        PoolObjectSpawner<PoolEntity> spawner;
        private void OnEnable()
        {
            GameEventBus.OnPlatformSpawn.AddListener(OnObstacleSpawn);
        }
        private void OnDisable()
        {
            GameEventBus.OnPlatformSpawn.RemoveListener(OnObstacleSpawn);
        }
        public void OnObstacleSpawn(GameObject obstacle)
        {
            int index = Random.Range(0, maxSpawns);
            Transform[] spawnPoints = GetSpawnPoints(obstacle);
            ISpawnPointStrategy spawnPointStrategy = new RandomSpawnPointStrategy(spawnPoints);
            spawner = new PoolObjectSpawner<PoolEntity>(
                new PoolEntityFactory<PoolEntity>(staminaCollectibleData),
                spawnPointStrategy);
            for (int i = 0; i < index; i++)
            {
                Spawn();
            }
        }   
        public void Spawn() => spawner.Spawn();
        private Transform[] GetSpawnPoints(GameObject obstacle)
        {
            List<Transform> spawnPointsTransforms = new(obstacle.GetComponentsInChildren<Transform>());
            spawnPointsTransforms.RemoveAt(0);
            return spawnPointsTransforms.ToArray();
        }
    }
}