using UnityEngine;

namespace TheCreators.PoolingSystem
{
    public class GameObjectDisabler : MonoBehaviour
    {
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.GetComponent<PoolObject>() != null)
                collision.gameObject.SetActive(false);
        }
    }
}