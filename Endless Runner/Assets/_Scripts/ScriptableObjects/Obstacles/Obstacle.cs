using UnityEngine;

namespace TheCreators.ScriptableObjects.Obstacles
{
    [CreateAssetMenu(menuName = "Obstacle", fileName = "newObstacle")]
    public class Obstacle : ScriptableObject
    {
        public GameObject prefab;
        [Range(0f, 100f)] public float chance = 100f;
        [ReadOnly] public double weight;
    }
}