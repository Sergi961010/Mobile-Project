using UnityEngine;

namespace TheCreators.ScriptableObjects.LevelParts
{
    [CreateAssetMenu(menuName = "LevelPart", fileName = "newLevelPart")]
    public class LevelPart : ScriptableObject
    {
        public GameObject prefab;
        [Range(0f, 100f)] public float chance = 100f;
        [ReadOnly] public double weight;
    }
}