using System.Collections;
using TheCreators.EventSystem;
using UnityEngine;

namespace TheCreators.Platforms
{
    public class FallingComponent : MonoBehaviour
    {
        private readonly float _fallSpeed = 0.1f;
        private void OnEnable()
        {
            StartCoroutine(Fall(2f));
        }

        IEnumerator Fall(float delay)
        {
            yield return new WaitForSeconds(delay);

            Vector2 startingPos = transform.position;
            Vector2 finalPos = transform.position + (Vector3.down * 5);

            while (startingPos.y > finalPos.y)
            {
                transform.position += _fallSpeed * Time.deltaTime * Vector3.down;
                yield return null;
            }
        }
    }
}
