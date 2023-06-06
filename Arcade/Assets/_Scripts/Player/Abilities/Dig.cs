using TheCreators.CustomEventSystem;
using UnityEngine;

namespace TheCreators.Player.Abilities
{
    public class Dig : MonoBehaviour
    {
        private void OnEnable()
        {
            GameEvent.Dig.AddListener(Burrow);
        }
        private void OnDisable()
        {
            GameEvent.Dig.RemoveListener(Burrow);
        }

        private void Burrow()
        {
            transform.position = new Vector2(transform.position.x, -2.88f);
        }
    }
}
