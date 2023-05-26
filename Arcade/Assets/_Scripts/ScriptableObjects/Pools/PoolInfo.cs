using System.Collections.Generic;
using TheCreators.Enums;
using TheCreators.ScriptableObjects.Platforms;
using UnityEngine;

namespace TheCreators.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewPoolInfo", menuName = "PoolInfo")]
    public class PoolInfo : ScriptableObject
    {
        public string poolType;
        public int size = 0;
        public GameObject prefab;
        public string containerName;
    }
}