using TheCreators.EventSystem;
using TheCreators.Managers;
using TheCreators.Enums;
using TheCreators.Utilities;
using TheCreators.ScriptableObjects;
using UnityEngine;
using System.Collections.Generic;

namespace TheCreators.Platforms
{
    public class PlatformSpawner : MonoBehaviour
    {
        private const int GAP_OFFSET = 2;
        [SerializeField] private List<Platform> _platforms;
        private Dictionary<PlatformTag, GameObject> _platformsDictionary;

        private PlatformTag _newPlatformTag;
        private int _gapCounter, _spawnWithGap;
        private void Awake()
        {
            _platformsDictionary = new Dictionary<PlatformTag, GameObject>();
            _spawnWithGap = Utility.RandomValue(0, 10);
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
            GameEvent.onPlatformSpawn.AddListener(OnPlatformSpawn);
        }

        private void OnPlatformSpawn(Vector2 previousPlatformPosition)
        {
            Vector2 spawnPosition = CalculateNextPlatformPosition(previousPlatformPosition);
            PlatformPoolManager.Instance.SpawnFromPool(_newPlatformTag, spawnPosition, Quaternion.identity);
        }

        private Vector2 CalculateNextPlatformPosition(Vector2 previousPlatformPosition)
        {
            _newPlatformTag = Utility.RandomEnumValue<PlatformTag>();
            float platformToSpawnHalfSize = _platformsDictionary[_newPlatformTag].GetComponent<BoxCollider2D>().size.x / 2;
            Vector2 spawnPosition = new(previousPlatformPosition.x + platformToSpawnHalfSize, previousPlatformPosition.y);

            if (_gapCounter == _spawnWithGap)
            {
                AddGapOnX(spawnPosition);
            } else
            {
                ++_gapCounter;
            }

            return spawnPosition;
        }

        private void AddGapOnX(Vector2 positionX)
        {
            positionX.x += GAP_OFFSET;
            _gapCounter = 0;
            _spawnWithGap = Utility.RandomValue(0, 5);
        }
    }
}