using UnityEngine;
using TheCreators.PoolingSystem;

namespace TheCreators.Platforms
{
    public class PlatformSpawner : MonoBehaviour
    {
        private const float PLAYER_DISTANCE_TO_END_POINT = 20f;

        [SerializeField] private Transform _startingPlatform;
        [SerializeField] private Transform _playerTransform;

        [SerializeField] private GameObject[] prefabs;

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
        private void SpawnLevelPart()
        {
            int random = Random.Range(0, prefabs.Length);
            GameObject platformToSpawn = PoolsManager.Instance.GetObject(prefabs[random]);
            float platformToSpawnHalfSize = platformToSpawn.GetComponentInChildren<BoxCollider2D>().size.x / 2;
            Vector2 spawnPosition = new(_lastEndPosition.x + platformToSpawnHalfSize, _lastEndPosition.y);
            platformToSpawn.SetActive(true);
            platformToSpawn.transform.position = spawnPosition;
            _lastEndPosition = platformToSpawn.transform.Find("EndPosition").position;
        }
    }
}