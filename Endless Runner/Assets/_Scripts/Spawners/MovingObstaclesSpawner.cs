using TheCreators.CustomEventSystem;
using UnityEngine;

namespace TheCreators
{
    public class MovingObstaclesSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _prebaf;
        [SerializeField] private Transform _spawnPoint;
        private void OnEnable()
        {
            GameEvent.OnAlertFinished.AddListener(Spawn);   
        }
        private void Spawn()
        {
            Instantiate(_prebaf, _spawnPoint.position, Quaternion.identity);
        }
    }
}
