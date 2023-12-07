using System.Collections;
using UnityEngine;

namespace TheCreators.CoreSystem.CoreComponents
{
    public class Movement : CoreComponent
    {
        public Rigidbody2D Rigidbody { get; private set; }
        private Vector2 workspace;
        protected override void Awake()
        {
            base.Awake();
            Rigidbody = GetComponentInParent<Rigidbody2D>();
        }
        private void OnDisable()
        {
            ResetVelocity();
        }
        public void ResetVelocity()
        {
            workspace.Set(0, 0);
            Rigidbody.velocity = workspace;
        }
        public void Jump(float jumpHeight, float jumpTimeToApex)
        {
            float jumpForce = CalculateJumpForce(jumpHeight, jumpTimeToApex);
            Rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        public void Fly(float value)
        {
            workspace.Set(workspace.x, value);
            Rigidbody.velocity = workspace;
        }
        public void ModifyGravity(float value) => Rigidbody.gravityScale *= value;
        public void ResetGravityScale() => Rigidbody.gravityScale = 1;
        public void ModifyYVelocity(float value)
        {
            Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, Rigidbody.velocity.y * value);
        }
        public void HandleDigTranslation(float endYPosition)
        {
            float newPositionY = Mathf.MoveTowards(transform.position.y, endYPosition, (6f * 1.5f) * Time.fixedDeltaTime);
            Vector2 newPosition = new(Rigidbody.position.x, newPositionY);
            Rigidbody.MovePosition(newPosition);
        }
        private float CalculateJumpForce(float jumpHeight, float jumpTimeToApex)
        {
            float gravityStrength = -(2 * jumpHeight) / Mathf.Pow(jumpTimeToApex, 2);

            Rigidbody.gravityScale = gravityStrength / Physics2D.gravity.y;

            return Mathf.Abs(gravityStrength) * jumpTimeToApex;
        }
    }
}