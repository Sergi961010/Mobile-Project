using System.Collections.Generic;
using TheCreators.ScriptableObjects.LevelParts;
using UnityEngine;

namespace TheCreators.ScriptableObjects.Spawners
{
    [CreateAssetMenu(menuName = "Spawner config/Level parts spawner", fileName = "NewLevelPartSpawnerConfig")]
    public class LevelPartSpawnerConfiguration : ScriptableObject
    {
        public List<LevelPart> levelParts = new();
        [ReadOnly] public double accumulatedWeights;
        private void OnValidate()
        {
            CalculateWeights();
        }
        private void CalculateWeights()
        {
            accumulatedWeights = 0f;
            foreach (var levelPart in levelParts)
            {
                accumulatedWeights += levelPart.chance;
                levelPart.weight = accumulatedWeights;
            }
        }
    }
}