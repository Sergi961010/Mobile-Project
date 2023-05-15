using TheCreators.Enums;
using UnityEngine;

namespace TheCreators.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewPlatform", menuName = "Platform")]
    public class Platform : ScriptableObject
    {
        public PlatformTag tag;
        public GameObject prefab;
    }
}
