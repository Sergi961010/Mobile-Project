using UnityEngine;

namespace TheCreators.SpawnSystem
{
    [CreateAssetMenu(menuName = "Scriptable Objects/SpawnerData/WeightedSpawnerData", fileName = "new WeightedSpawnerData")]
    public class WeightedSpawnerData : SpawnerData
    {
        [ReadOnly] public double accumulatedWeights;
        private void OnValidate()
        {
            CalculateWeights();
        }
        private void CalculateWeights()
        {
            accumulatedWeights = 0f;
            foreach (var item in data)
            {
                accumulatedWeights += item.chance;
                item.weight = accumulatedWeights;
            }
        }
    }
}