using TheCreators.Enums.Platforms;
using UnityEngine;

namespace TheCreators.ScriptableObjects.Platforms
{
    [CreateAssetMenu(fileName = "NewBasicPlatform", menuName = "Platforms/BasicPlatform")]
    public class Platform : ScriptableObject
    {
        public Tag tag;
        public GameObject prefab;
        public Vector2 endPosition;
    }
}
