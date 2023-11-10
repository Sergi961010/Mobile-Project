using System.Collections.Generic;
using TheCreators.CustomEventSystem;
using UnityEngine;

namespace TheCreators
{
    public class StaminaPropSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _staminaProp;
        [SerializeField] private int minNumberOfProps = 0;
        [SerializeField] private int maxNumberOfProps = 2;
        private void OnEnable()
        {
            GameEventBus.OnPlatformSpawn.AddListener(SpawnProps);
        }
        private void OnDisable()
        {
            GameEventBus.OnPlatformSpawn.RemoveListener(SpawnProps);
        }
        private void SpawnProps(GameObject levelPart)
        {
            List<Transform> spawnPoints = GetSpawnPoints(levelPart);
            int numberOfProps = Random.Range(minNumberOfProps, maxNumberOfProps);
            for (int i = 0; i < numberOfProps; i++)
            {
                int random = Random.Range(0, spawnPoints.Count);
                Vector3 spawnPoint = spawnPoints[random].position;
                Instantiate(_staminaProp, spawnPoint, Quaternion.identity);
                spawnPoints.RemoveAt(random);
            }
        }
        private List<Transform> GetSpawnPoints(GameObject levelPart)
        {
            Transform spawnPointsContainer = levelPart.transform.Find("StaminaSpawns");
            List<Transform> spawnPointsTransforms = new(spawnPointsContainer.GetComponentsInChildren<Transform>());
            spawnPointsTransforms.RemoveAt(0);
            return spawnPointsTransforms;
        }
    }
}
