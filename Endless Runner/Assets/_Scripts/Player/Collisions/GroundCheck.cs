using UnityEngine;
using TheCreators.CustomEventSystem;

namespace TheCreators.Player
{
    public class GroundCheck : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            GameEvent.OnGroundCollision.Invoke();
        }
    }
}
