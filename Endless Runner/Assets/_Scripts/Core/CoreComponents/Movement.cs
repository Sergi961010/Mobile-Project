using System.Collections;
using UnityEngine;

namespace TheCreators.CoreSystem.CoreComponents
{
    public class Movement : BaseCoreComponent
    {
        public Rigidbody2D Rigidbody { get; private set; }
        private Vector2 workspace;
        private float digElapsedTime;
        protected override void Awake()
        {
            base.Awake();
            Rigidbody = GetComponentInParent<Rigidbody2D>();
        }
        private void Start()
        {
            SetXVelocity(6);
        }
        public void SetXVelocity(float value)
        {
            workspace.Set(value, workspace.y);
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
        public IEnumerator HandleBurrow(float duration, float surfaceYPosition, float undergroundYPosition)
        {
            Vector2 newPosition = transform.position;
            float percentageComplete = digElapsedTime / duration;
            digElapsedTime += Time.deltaTime;
            newPosition.x = transform.position.x + Rigidbody.velocity.x * Time.deltaTime;
            newPosition.y = Mathf.Lerp(surfaceYPosition, undergroundYPosition, percentageComplete);
            Rigidbody.isKinematic = true;
            Rigidbody.MovePosition(newPosition);
            yield return new WaitForSeconds(duration);
            digElapsedTime = 0;
        }
        public void HandleUnburrow(float duration, float surfaceYPosition, float undergroundYPosition)
        {
            Vector2 newPosition = transform.position;
            float percentageComplete = digElapsedTime / duration;
            digElapsedTime += Time.deltaTime;
            newPosition.x = transform.position.x + Rigidbody.velocity.x * Time.deltaTime;
            newPosition.y = Mathf.Lerp(undergroundYPosition, surfaceYPosition, percentageComplete);
            Rigidbody.MovePosition(newPosition);

            if (digElapsedTime >= duration)
            {
                Rigidbody.isKinematic = false;
                digElapsedTime = 0;
            }
        }
        private float CalculateJumpForce(float jumpHeight, float jumpTimeToApex)
        {
            float gravityStrength = -(2 * jumpHeight) / Mathf.Pow(jumpTimeToApex, 2);

            Rigidbody.gravityScale = gravityStrength / Physics2D.gravity.y;

            return Mathf.Abs(gravityStrength) * jumpTimeToApex;
        }
    }
}