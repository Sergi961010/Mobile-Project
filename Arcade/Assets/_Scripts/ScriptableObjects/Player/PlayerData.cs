using TheCreators.Managers;
using UnityEngine;

namespace TheCreators.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewPlayerData", menuName = "Data/Player")]
    public class PlayerData : ScriptableObject
    {
        #region Jump
        public float jumpForce = 5f;
        #endregion

        #region Gravity
        public float defaultGravityModifier = 0.75f;
        public float jumpCutGravityModifier = 2f;
        #endregion

        public float CalculateJumpXDistance(float gravityModifier)
        {
            float gravityModified = Physics2D.gravity.magnitude * gravityModifier;
            float timeOfJump = 2 * jumpForce / gravityModified;
            float xDistanceTravelled = timeOfJump * GameManager.Instance.GameVelocity.x;
            return xDistanceTravelled;
        }
    }
}
