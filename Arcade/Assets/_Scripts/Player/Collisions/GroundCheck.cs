using UnityEngine;
using TheCreators.EventSystem;

namespace TheCreators.Player
{
    public class GroundCheck : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            GameEvent.onGroundCollision.Invoke();
        }
    }
}
