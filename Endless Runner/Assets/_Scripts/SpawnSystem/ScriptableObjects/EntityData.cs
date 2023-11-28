using UnityEngine;

namespace TheCreators.SpawnSystem
{
    public class EntityData : ScriptableObject
    {
        public GameObject prefab;
        [Range(0f, 100f)] public float chance = 100f;
        [ReadOnly] public double weight;
    }
}