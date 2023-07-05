using TheCreators.Enums.Platforms;
using UnityEngine;

namespace TheCreators.ScriptableObjects.Platforms
{
    [CreateAssetMenu(fileName = "NewLevelPart", menuName = "LevelPart")]
    public class LevelPart : ScriptableObject
    {
        public Tag tag;
        public GameObject prefab;
    }
}