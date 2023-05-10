using System.Collections.Generic;
using UnityEngine;

namespace TheCreators.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewPool", menuName = "Pool")]
    public class Pool : ScriptableObject
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }
}