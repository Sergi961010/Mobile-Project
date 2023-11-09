using UnityEngine;

namespace TheCreators
{
    public class GameObjectDisabler : MonoBehaviour
    {
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.transform.parent == null)
                collision.gameObject.SetActive(false);
            else
                collision.transform.parent.gameObject.SetActive(false);
        }
    }
}