using TheCreators.Enums.Platforms;
using UnityEngine;

namespace TheCreators.ScriptableObjects.Platforms
{
    [CreateAssetMenu(fileName = "NewStandardPlatform", menuName = "Platform/StandardPlatform")]
    public class Platform : ScriptableObject
    {
        public Tag tag;
        public GameObject prefab;
    }
}
