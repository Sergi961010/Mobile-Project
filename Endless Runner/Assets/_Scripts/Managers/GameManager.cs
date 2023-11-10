using TheCreators.Enums;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace TheCreators.Managers
{
    public class GameManager : MonoBehaviour
    {
        private bool _adDisplayed = false;
        [SerializeField] private UiManager _uiManager;
        public UnityEvent GameOverEvent;
        private void OnEnable()
        {
            Application.targetFrameRate = 60;
        }
        public void CheckIfShouldDisplayAd()
        {
            if (!_adDisplayed)
            {
                _uiManager.EnableRewardAdButton();
                _adDisplayed = true;
            }
            else
                GameOver();
        }
        public void GameOver()
        {
            GameOverEvent.Invoke();
        }
    }
}