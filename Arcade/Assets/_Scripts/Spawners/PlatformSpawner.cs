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

        [SerializeField] private List<Platform> _platforms;
        private Dictionary<Tag, GameObject> _platformsDictionary;

        [SerializeField] private PlayerData _playerData;

        private int _gapCounter, _spawnWithGap;
        [SerializeField] private Transform _spawnPoint;
        private void Awake()
        {
            _platformsDictionary = new Dictionary<Tag, GameObject>();
            _spawnWithGap = 5;
            _gapCounter = 0;
        }
        private void Start()
        {
            foreach (Platform platform in _platforms)
            {
                _platformsDictionary.Add(platform.tag, platform.prefab);
            }
        }
        private void OnEnable()
        {
            GameEvent.OnPlatformSpawn.AddListener(OnPlatformSpawn);
        }

        private void OnPlatformSpawn()
        {
            GameObject platformToSpawn = PlatformPoolManager.Instance.RequestLevelPart(GetPoolType());
            PositionLevelPart(platformToSpawn);
        }

        private void PositionLevelPart(GameObject platformToSpawn)
        {
            float platformToSpawnHalfSize = platformToSpawn.GetComponent<BoxCollider2D>().size.x / 2;
            Vector2 spawnPosition = new(_spawnPoint.position.x + platformToSpawnHalfSize, _spawnPoint.position.y);

            //if (_fallingCounter == _spawnWithFall) return spawnPosition;

            if (_gapCounter == _spawnWithGap)
            {
                spawnPosition = AddGapOnX(spawnPosition);
            }

            platformToSpawn.transform.position = spawnPosition;
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

        private PoolType GetPoolType()
        {
            PoolType result;

            if (_gapCounter == _spawnWithGap)
            {
                result = PoolType.Basic;
                _gapCounter = 0;
                _spawnWithGap = Random.Range(0, 4);
            }
            else
            {
                result = Utility.RandomEnumValue<PoolType>();
                ++_gapCounter;
            }

            return result;
        }
    }
}