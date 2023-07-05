using UnityEngine;

namespace TheCreators.Spawners
{
    public class LaserSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private GameObject _laser;

        [SerializeField] private float _minTimeToSpawn = 4f, _maxTimeToSpawn = 5f;
        private float _spawnTime;

        private void Start()
        {
            _spawnTime = Random.Range(_minTimeToSpawn, _maxTimeToSpawn);
        }
        private void Update()
        {
            if (_spawnTime <= 0)
            {
                Spawn();
            }
            _spawnTime -= Time.deltaTime;
        }
        private void Spawn()
        {
            Instantiate(_laser, _spawnPoint.position, Quaternion.identity);
            _spawnTime = Random.Range(_minTimeToSpawn, _maxTimeToSpawn);
        }
    }
}
