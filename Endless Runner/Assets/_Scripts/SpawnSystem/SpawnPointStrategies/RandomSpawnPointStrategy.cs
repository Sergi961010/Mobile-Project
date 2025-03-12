using System.Collections.Generic;
using UnityEngine;

namespace TheCreators.SpawnSystem
{
    public class RandomSpawnPointStrategy : ISpawnPointStrategy
    {
        List<Transform> unusedSpawnPoints;
        readonly Transform[] spawnPoints;
        public RandomSpawnPointStrategy(Transform[] spawnPoints)
        {
            this.spawnPoints = spawnPoints;
            unusedSpawnPoints = new List<Transform>(spawnPoints);
        }
        public Transform NextSpawnPoint()
        {
            if (unusedSpawnPoints.Count == 0)
            {
                unusedSpawnPoints = new List<Transform>(spawnPoints);
            }
            var randomIndex = Random.Range(0, unusedSpawnPoints.Count);
            Transform result = unusedSpawnPoints[randomIndex];
            unusedSpawnPoints.RemoveAt(randomIndex);
            return result;
        }
    }
}