using UnityEngine;

namespace TheCreators.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewJumpData", menuName = "Data/Player/Jump")]
    public class JumpData : ScriptableObject
    {
        [Header("Gravity")]
        [ReadOnly] public float gravityStrength;
        [ReadOnly] public float gravityScale;
        public float fallGravityMultiplier = 2f;
        [Header("Jump")]
        [ReadOnly] public float jumpForce;
        public float jumpHeight = 2f;
        public float jumpTimeToApex = .5f;
        public float jumpHangTimeThreshold = .1f;
        [Range(0f, 1)] public float jumpHangGravityMultiplier = .5f;
        private void OnValidate()
        {
            gravityStrength = -(2 * jumpHeight) / Mathf.Pow(jumpTimeToApex, 2);

            gravityScale = gravityStrength / Physics2D.gravity.y;

            jumpForce = Mathf.Abs(gravityStrength) * jumpTimeToApex;
        }
    }
}
