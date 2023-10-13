using TheCreators.CustomEventSystem;
using UnityEngine;
using UnityEngine.UI;

namespace TheCreators
{
    public class UiManager : MonoBehaviour
    {
        [SerializeField] private GameObject _alert;
        [SerializeField] private Button _rewardAdButton;
        private void OnEnable()
        {
            GameEvent.OnScreenObstacleTrigger.AddListener(EnableAlert);
            GameEvent.OnPlayerDeath.AddListener(EnableRewardAdButton);
        }
        private void OnDisable()
        {
            GameEvent.OnScreenObstacleTrigger.RemoveListener(EnableAlert);
            GameEvent.OnPlayerDeath.RemoveListener(EnableRewardAdButton);
        }
        private void EnableAlert()
        {
            _alert.SetActive(true);
        }
        private void EnableRewardAdButton()
        {
            _rewardAdButton.gameObject.SetActive(true);
        }
    }
}