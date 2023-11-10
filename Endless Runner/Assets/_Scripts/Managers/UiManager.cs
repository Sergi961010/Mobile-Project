using TheCreators.CustomEventSystem;
using UnityEngine;

namespace TheCreators
{
    public class UiManager : MonoBehaviour
    {
        [SerializeField] private GameObject _alert;
        [SerializeField] private GameObject _rewardAdButton;
        [SerializeField] private GameObject _pauseMenu;
        private void OnEnable()
        {
            GameEventBus.OnScreenObstacleTrigger.AddListener(EnableAlert);
        }
        private void OnDisable()
        {
            GameEventBus.OnScreenObstacleTrigger.RemoveListener(EnableAlert);
        }
        private void EnableAlert()
        {
            _alert.SetActive(true);
        }
        public void EnablePauseMenu()
        {
            _pauseMenu.SetActive(true);
        }
        public void EnableRewardAdButton()
        {
            _rewardAdButton.gameObject.SetActive(true);
        }
    }
}