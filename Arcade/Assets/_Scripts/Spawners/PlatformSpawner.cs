using TheCreators.EventSystem;
using TheCreators.Managers;
using TheCreators.Enums;
using TheCreators.Enums.Platforms;
using TheCreators.ScriptableObjects.Platforms;
using UnityEngine;
using System.Collections.Generic;
using TheCreators.ScriptableObjects;
using TheCreators.Utilities;

namespace TheCreators.Platforms
{
    public class PlatformSpawner : MonoBehaviour
    {
        private const float PLAYER_DISTANCE_TO_END_POINT = 20f;

        [SerializeField] private Transform _startingPlatform;
        [SerializeField] private Transform _playerTransform;

        [SerializeField] private List<Platform> _platforms;
        private Dictionary<Tag, GameObject> _platformsDictionary;

        [SerializeField] private PlayerData _playerData;

        private Vector2 _lastEndPosition;

        private int _gapCounter, _spawnWithGap;
        [SerializeField] private Transform _spawnPoint;
        private void Awake()
        {
            _platformsDictionary = new Dictionary<Tag, GameObject>();
            _spawnWithGap = 5;
            _gapCounter = 0;
            _lastEndPosition = _startingPlatform.Find("EndPosition").position;
        }
        private void Start()
        {
            foreach (Platform platform in _platforms)
            {
                _platformsDictionary.Add(platform.tag, platform.prefab);
            }
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
            GameObject platformToSpawn = PlatformPoolManager.Instance.RequestLevelPart(PoolType.Basic);
            float platformToSpawnHalfSize = platformToSpawn.GetComponent<BoxCollider2D>().size.x / 2;
            Vector2 spawnPosition = new(_lastEndPosition.x + platformToSpawnHalfSize, _lastEndPosition.y);

            platformToSpawn.transform.position = spawnPosition;
            _lastEndPosition = platformToSpawn.transform.Find("EndPosition").position;
        }

        private Vector2 AddGapOnX(Vector2 position)
        {
            position.x += GetRandomBetweenJumpDistances();
            return position;
        }

        private float GetRandomBetweenJumpDistances()
        {
            float minJumpXDistance = _playerData.CalculateJumpXDistance(_playerData.jumpCutGravityModifier);
            float maxJumpXDistance = _playerData.CalculateJumpXDistance(_playerData.defaultGravityModifier);
            float result = Random.Range(minJumpXDistance, maxJumpXDistance);
            return result;
        }

    }
}