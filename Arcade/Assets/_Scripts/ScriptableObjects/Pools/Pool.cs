using System.Collections.Generic;
using TheCreators.Enums;
using TheCreators.ScriptableObjects.Platforms;
using UnityEngine;

namespace TheCreators.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewPool", menuName = "Pool")]
    public class Pool : ScriptableObject
    {
        public List<Platform> levelParts;
        public int levelPartAmount = 2;
        public PoolType poolType;
    }
}