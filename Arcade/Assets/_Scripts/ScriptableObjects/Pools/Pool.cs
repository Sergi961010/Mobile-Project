using TheCreators.ScriptableObjects.Platforms;
using UnityEngine;

namespace TheCreators.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewPool", menuName = "Pool")]
    public class Pool : ScriptableObject
    {
        public Platform platform;
        public int size = 2;
    }
}