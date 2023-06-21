using TheCreators.CustomEventSystem;
using UnityEngine;
using UnityEngine.UI;

namespace TheCreators
{
    public class UiManager : MonoBehaviour
    {
        [SerializeField] private GameObject _alert;
        private void OnEnable()
        {
            GameEvent.OnScreenObstacleTrigger.AddListener(EnableAlert);
        }
        private void OnDisable()
        {
            GameEvent.OnScreenObstacleTrigger.RemoveListener(EnableAlert);
        }
        private void EnableAlert()
        {
            _alert.SetActive(true);
        }
    }
}
