using UnityEngine;
using UnityEngine.Events;

namespace TheCreators.Managers
{
    public class GameManager : MonoBehaviour
    {
        private bool _adDisplayed = false;
        [SerializeField] private UiManager _uiManager;
        public UnityEvent GameOverEvent;

        public static float GameSpeed = 6f;
        private void OnEnable()
        {
            Application.targetFrameRate = 60;
        }
        public void OnPlayerDeath() => CheckIfShouldDisplayAd();
        public void OnPlayerCollisionWithObstacle() { }
        public void GameOver()
        {
            GameOverEvent.Invoke();
        }
        private void CheckIfShouldDisplayAd()
        {
            if (!_adDisplayed)
            {
                _uiManager.EnableRewardAdButton();
                _adDisplayed = true;
            }
            else
                GameOver();
        }
    }
}