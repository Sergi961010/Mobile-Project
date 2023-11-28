using UnityEngine;
using TheCreators.PoolingSystem;
using TheCreators.CustomEventSystem;
using TheCreators.SpawnSystem;

namespace TheCreators.Spawners
{
    public class ObstacleSpawner : MonoBehaviour
    {
        private float _distanceBetweenObstacles;

        private Transform _previousObstacleTransform;

        [SerializeField] private WeightedSpawnerData data;

        private void Start()
        {
            SpawnObstacle();
        }
        private void Update()
        {
            if (Vector2.Distance(transform.position, _previousObstacleTransform.position) >= _distanceBetweenObstacles)
            {
                SpawnObstacle();
            }
        }
        private GameObject GetRandomObstacle()
        {
            System.Random random = new();
            double roll = random.NextDouble() * data.accumulatedWeights;
            for (int i = 0; i < data.data.Count; i++)
            {
                if (data.data[i].weight >= roll)
                    return PoolsManager.Instance.GetObject(data.data[i].prefab);
            }
            return PoolsManager.Instance.GetObject(data.data[0].prefab);
        }
        public void SpawnObstacle()
        {
            GameObject obstacleToSpawn = GetRandomObstacle();
            obstacleToSpawn.SetActive(true);
            obstacleToSpawn.transform.position = transform.position;
            _previousObstacleTransform = obstacleToSpawn.transform;
            _distanceBetweenObstacles = obstacleToSpawn.GetComponent<Collider2D>().bounds.size.x / 2f + 8f;
            GameEventBus.OnPlatformSpawn.Invoke(obstacleToSpawn);
        }
    }
}