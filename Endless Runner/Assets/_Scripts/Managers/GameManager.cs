using TheCreators.Enums;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TheCreators.Managers
{
    public class GameManager : MonoBehaviour
    {
        private bool _adDisplayed = false;
        [SerializeField] private UiManager _uiManager;
        private void OnEnable()
        {
            Application.targetFrameRate = 60;
        }
        public void GameOver()
        {
            if (!_adDisplayed)
            {
                _uiManager.EnableRewardAdButton();
                _adDisplayed = true;
            } else
            {
                SceneManager.LoadScene((int)SceneID.MainMenu);
            }
        }
    }
}