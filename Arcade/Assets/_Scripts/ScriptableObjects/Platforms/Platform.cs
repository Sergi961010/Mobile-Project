using TheCreators.Enums.Platforms;
using UnityEngine;

namespace TheCreators.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewPlatform", menuName = "Platform")]
    public class Platform : ScriptableObject
    {
        public Tag tag;
        public GameObject prefab;
    }
}
