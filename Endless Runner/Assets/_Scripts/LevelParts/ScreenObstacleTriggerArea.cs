using TheCreators.CustomEventSystem;
using UnityEngine;

namespace TheCreators.LevelParts
{
    public class ScreenObstacleTriggerArea : MonoBehaviour
    {
        [SerializeField] private string _tagOfInterest;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(_tagOfInterest))
            {
                GameEventBus.OnScreenObstacleTrigger.Invoke();
            }
        }
    }
}