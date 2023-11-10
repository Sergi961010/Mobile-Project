using UnityEngine;
using TheCreators.PoolingSystem;
using TheCreators.CustomEventSystem;
using TheCreators.ScriptableObjects.Spawners;

namespace TheCreators.Platforms
{
    public class PlatformSpawner : MonoBehaviour
    {
        private const float PLAYER_DISTANCE_TO_END_POINT = 20f;

        [SerializeField] private Transform _startingPlatform;
        [SerializeField] private Transform _playerTransform;

        [SerializeField] private LevelPartSpawnerConfiguration _configuration;

        private Vector2 _lastEndPosition;

        private void Start()
        {
            _lastEndPosition = _startingPlatform.Find("EndPosition").position;
        }
        private void Update()
        {
            if (Vector2.Distance(_playerTransform.position, _lastEndPosition) < PLAYER_DISTANCE_TO_END_POINT)
            {
                SpawnLevelPart();
            }
        }
        private GameObject GetRandomLevelPart()
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
        private void SpawnLevelPart()
        {
            GameObject levelPartToSpawn = GetRandomLevelPart();
            float platformToSpawnHalfSize = levelPartToSpawn.GetComponentInChildren<BoxCollider2D>().size.x / 2;
            Vector2 spawnPosition = new(_lastEndPosition.x + platformToSpawnHalfSize, _lastEndPosition.y);
            levelPartToSpawn.SetActive(true);
            levelPartToSpawn.transform.position = spawnPosition;
            _lastEndPosition = levelPartToSpawn.transform.Find("EndPosition").position;
            GameEventBus.OnPlatformSpawn.Invoke(levelPartToSpawn);
        }
    }
}