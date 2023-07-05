using UnityEngine;

namespace TheCreators
{
    public class GameObjectDisabler : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask;
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (((1 << collision.gameObject.layer) & _layerMask) != 0)
                collision.transform.parent.gameObject.SetActive(false);
        }
    }
}