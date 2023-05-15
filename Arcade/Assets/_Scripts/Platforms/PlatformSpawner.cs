using TheCreators.EventSystem;
using TheCreators.Managers;
using TheCreators.Enums;
using TheCreators.Utilities;
using UnityEngine;
using System.Collections.Generic;
using TheCreators.ScriptableObjects;

namespace TheCreators.Platforms
{
    public class PlatformSpawner : MonoBehaviour
    {
        [SerializeField] private List<Platform> _platforms;
        private Dictionary<PlatformTag, GameObject> _platformsDictionary;
        private void Awake()
        {
            _platformsDictionary = new Dictionary<PlatformTag, GameObject>();
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

        private void OnPlatformSpawn(float xPosition)
        {
            PlatformTag platformTag = Utility.RandomEnumValue<PlatformTag>();
            float xOffset = _platformsDictionary[platformTag].GetComponent<BoxCollider2D>().size.x / 2;
            Vector2 spawnPosition = new(xPosition + xOffset, -3.64f);
            PlatformPoolManager.Instance.SpawnFromPool(platformTag, spawnPosition, Quaternion.identity);
        }
    }
}