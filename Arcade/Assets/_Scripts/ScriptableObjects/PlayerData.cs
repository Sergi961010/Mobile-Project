using UnityEngine;

namespace TheCreators.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewPlayerData", menuName = "Data/Player")]
    public class PlayerData : ScriptableObject
    {
        public float Speed = 2f;
    }
}
