using UnityEngine;
using TheCreators.PoolingSystem;
using TheCreators.CustomEventSystem;

namespace TheCreators.Platforms
{
    public class PlatformSpawner : MonoBehaviour
    {
        private const float PLAYER_DISTANCE_TO_END_POINT = 20f;

        [SerializeField] private Transform _startingPlatform;
        [SerializeField] private Transform _playerTransform;

        [SerializeField] private GameObject[] levelParts;

        private readonly int amountOfRegularLevelParts = 5;
        private int _counter;
        private Vector2 _lastEndPosition;

        private void Start()
        {
            _lastEndPosition = _startingPlatform.Find("EndPosition").position;
            _counter = 1;
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
            int random = Random.Range(0, levelParts.Length);
            GameObject platformToSpawn = PoolsManager.Instance.GetObject(levelParts[random]);
            return platformToSpawn;
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