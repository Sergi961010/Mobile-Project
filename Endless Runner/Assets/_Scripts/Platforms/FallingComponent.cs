using System.Collections;
using TheCreators.ScriptableObjects.Platforms;
using UnityEngine;

namespace TheCreators.Platforms
{
    public class FallingComponent : MonoBehaviour
    {
        [SerializeField] private FallingPlatform _platformData;
        private void OnEnable()
        {
            float randomDelay = Random.Range(_platformData.minDelay, _platformData.maxDelay);
            StartCoroutine(Fall(randomDelay));
        }

        IEnumerator Fall(float delay)
        {
            yield return new WaitForSeconds(delay);

            Vector2 startingPos = transform.position;
            Vector2 finalPos = transform.position + (Vector3.down * 5);

            while (startingPos.y > finalPos.y)
            {
                transform.position += _platformData.fallSpeed * Time.deltaTime * Vector3.down;
                yield return null;
            }
        }
    }
}
