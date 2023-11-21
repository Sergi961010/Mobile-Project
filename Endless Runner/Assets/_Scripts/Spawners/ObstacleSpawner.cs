using UnityEngine;
using TheCreators.PoolingSystem;
using TheCreators.CustomEventSystem;
using TheCreators.ScriptableObjects.Spawners;

namespace TheCreators.Spawners
{
    public class ObstacleSpawner : MonoBehaviour
    {
        private float _distanceBetweenObstacles;

        private Transform _previousObstacleTransform;

        [SerializeField] private LevelPartSpawnerConfiguration _configuration;

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
            double roll = random.NextDouble() * _configuration.accumulatedWeights;
            for (int i = 0; i < _configuration.levelParts.Count; i++)
            {
                if (_configuration.levelParts[i].weight >= roll)
                    return PoolsManager.Instance.GetObject(_configuration.levelParts[i].prefab);
            }
            return PoolsManager.Instance.GetObject(_configuration.levelParts[0].prefab);
        }
        private void SpawnObstacle()
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