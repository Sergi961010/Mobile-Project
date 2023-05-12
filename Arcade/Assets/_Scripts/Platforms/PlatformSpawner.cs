using TheCreators.EventSystem;
using TheCreators.Managers;
using UnityEngine;

namespace TheCreators.Platforms
{
    public class PlatformSpawner : MonoBehaviour
    {
        private void OnEnable()
        {
            GameEvent.onPlatformSpawn.AddListener(OnPlatformSpawn);
        }

        private void OnPlatformSpawn()
        {
            Vector2 spawnPosition = new(_cameraRightBoundary + _collider.size.x / 2 + SPAWN_OFFSET, transform.position.y);
            PoolsManager.Instance.SpawnFromPool("Platform1", spawnPosition, Quaternion.identity);
        }
    }
}