using TheCreators.EventSystem;
using TheCreators.Managers;
using TheCreators.Enums.Platforms;
using TheCreators.ScriptableObjects;
using UnityEngine;
using System.Collections.Generic;

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

            if (_gapCounter == _spawnWithGap)
            {
                spawnPosition = AddGapOnX(spawnPosition);
            } else
            {
                ++_gapCounter;
            }

            return spawnPosition;
        }

        private Vector2 AddGapOnX(Vector2 position)
        {
            position.x += GetRandomBetweenJumpDistances();
            _gapCounter = 0;
            _spawnWithGap = Random.Range(0, 4);
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
            int id;
            if (_fallingCounter == _spawnWithFall)
            {
                id = Random.Range(3, 4);
                _fallingCounter = 0;
            } else
            {
                id = Random.Range(0, 2);
                ++_fallingCounter;
            }
            return (Tag)id;
        }
    }
}