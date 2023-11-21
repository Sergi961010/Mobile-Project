using TheCreators.PoolingSystem;
using UnityEngine;

namespace TheCreators.Spawners
{
	public class GroundSpawner : MonoBehaviour
	{
        [SerializeField] private GameObject _groundPrefab;
        [SerializeField] private Transform _previousGroundTransform;
        [SerializeField] private float offSet;
        private float _groundHalfSize;
        private void Awake()
        {
            _groundHalfSize = _groundPrefab.GetComponent<BoxCollider2D>().size.x;
        }
        private void FixedUpdate()
        {
            if (Vector2.Distance(_previousGroundTransform.position, transform.position) >= _groundHalfSize)
                SpawnGround();
        }
        private void SpawnGround()
        {
            GameObject obstacleToSpawn = PoolsManager.Instance.GetObject(_groundPrefab);
            obstacleToSpawn.SetActive(true);
            obstacleToSpawn.transform.position = new(transform.position.x - offSet, transform.position.y, 0);
            _previousGroundTransform = obstacleToSpawn.transform;
        }
    }
}