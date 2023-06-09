using System.Collections;
using UnityEngine;

namespace TheCreators.Platforms
{
    public class PlatformController : MonoBehaviour
    {
        private void Start()
        {
            StartCoroutine(DeactivateWhenOutOfCamera());
        }

        private IEnumerator DeactivateWhenOutOfCamera()
        {
            yield return new WaitForSeconds(5f);
            gameObject.SetActive(false);
        }
    }
}