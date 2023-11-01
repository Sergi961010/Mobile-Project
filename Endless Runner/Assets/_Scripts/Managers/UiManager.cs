using TheCreators.CustomEventSystem;
using UnityEngine;
using UnityEngine.UI;

namespace TheCreators
{
    public class UiManager : MonoBehaviour
    {
        [SerializeField] private GameObject _alert;
        [SerializeField] private Button _rewardAdButton;
        [SerializeField] private GameObject _pauseMenu;
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