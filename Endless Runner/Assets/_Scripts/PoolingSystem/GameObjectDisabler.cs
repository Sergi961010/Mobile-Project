using UnityEngine;

namespace TheCreators
{
    public class GameObjectDisabler : MonoBehaviour
    {
        private void OnTriggerExit2D(Collider2D collision)
        {
            collision.transform.parent.gameObject.SetActive(false);
        }
    }
}