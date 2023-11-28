using TheCreators.CustomEventSystem;
using TheCreators.PoolingSystem;
using TheCreators.Utilities;
using UnityEngine;

namespace TheCreators.SpawnSystem
{
    public class ObstacleSpawnManager : EntitySpawnManager
    {
        [SerializeField] ObstacleData[] obstacleData;
        [SerializeField] float spawnInterval = 2f;
        PoolObjectSpawner<PoolEntity> spawner;
        CountdownTimer spawnTimer;
        protected override void Awake()
        {
            base.Awake();
            spawner = new PoolObjectSpawner<PoolEntity>(
                new PoolEntityWeightedFactory<PoolEntity>(obstacleData),
                spawnPointStrategy);
            spawnTimer = new CountdownTimer(spawnInterval);
            spawnTimer.OnTimerStop += () =>
            {
                Spawn();
                spawnTimer.Start();
            };
        }
        private void Start() => spawnTimer.Start();
        private void Update() => spawnTimer.Tick(Time.deltaTime);
        public override void Spawn()
        {
            var obstacleSpawned = spawner.Spawn();
            GameEventBus.OnPlatformSpawn.Invoke(obstacleSpawned.gameObject);
        }
    }
}