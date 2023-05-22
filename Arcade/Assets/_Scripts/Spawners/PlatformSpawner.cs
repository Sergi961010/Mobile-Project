using TheCreators.EventSystem;
using TheCreators.Managers;
using TheCreators.Enums.Platforms;
using TheCreators.ScriptableObjects.Platforms;
using UnityEngine;
using System.Collections.Generic;
using TheCreators.ScriptableObjects;

namespace TheCreators.Platforms
{
    public class PlatformSpawner : MonoBehaviour
    {

        [SerializeField] private List<Platform> _platforms;
        private Dictionary<Tag, GameObject> _platformsDictionary;

        [SerializeField] private PlayerData _playerData;

        private int _gapCounter, _spawnWithGap, _fallingCounter, _spawnWithFall;
        [SerializeField] private Transform _spawnPoint;
        private void Awake()
        {
            _platformsDictionary = new Dictionary<Tag, GameObject>();
            _spawnWithGap = 5;
            _spawnWithFall = Random.Range(6, 10);
            _gapCounter = 0;
            _fallingCounter = 0;
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
            Tag platformToSpawnTag = GetPlatformTag();
            Vector2 spawnPosition = CalculateNextPlatformPosition(platformToSpawnTag);
            PlatformPoolManager.Instance.GetPooledObject(platformToSpawnTag, spawnPosition, Quaternion.identity);
        }

        private Vector2 CalculateNextPlatformPosition(Tag platformToSpawnTag)
        {
            float platformToSpawnHalfSize = _platformsDictionary[platformToSpawnTag].GetComponent<BoxCollider2D>().size.x / 2;
            Vector2 spawnPosition = new(_spawnPoint.position.x + platformToSpawnHalfSize, _spawnPoint.position.y);

            //if (_fallingCounter == _spawnWithFall) return spawnPosition;

            if (_gapCounter == _spawnWithGap)
            {
                spawnPosition = AddGapOnX(spawnPosition);
            }

            return spawnPosition;
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

        private Tag GetPlatformTag()
        {
            int randomStandardPlatformTag = Random.Range(0, 3);
            int randomFallingPlatformTag = Random.Range(3, 5);
            Tag result;

            if (_gapCounter == _spawnWithGap)
            {
                result = (Tag)randomStandardPlatformTag;
                _gapCounter = 0;
                _spawnWithGap = Random.Range(0, 4);
            } else if (_fallingCounter == _spawnWithFall)
            {
                result = (Tag)randomFallingPlatformTag;
                _fallingCounter = 0;
                _spawnWithFall = Random.Range(6, 10);
            } else
            {
                result = (Tag)randomStandardPlatformTag;
                ++_gapCounter;
                ++_fallingCounter;
            }
            return result;
        }
    }
}