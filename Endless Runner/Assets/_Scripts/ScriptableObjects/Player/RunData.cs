using UnityEngine;

namespace TheCreators.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewPlayerData", menuName = "Data/Player")]
    public class RunData : ScriptableObject
    {
        public float Speed = 5f;
    }
}
