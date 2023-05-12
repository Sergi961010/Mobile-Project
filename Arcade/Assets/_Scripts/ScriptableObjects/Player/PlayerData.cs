using UnityEngine;

namespace TheCreators.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewPlayerData", menuName = "Data/Player")]
    public class PlayerData : ScriptableObject
    {
        public float Speed = 2f;

        #region Jump
        public float JumpForce = 100f;
        #endregion

        #region Gravity
        public float defaultGravity = 0.75f;
        public float jumpCutGravity = 2f;
        #endregion
    }
}
