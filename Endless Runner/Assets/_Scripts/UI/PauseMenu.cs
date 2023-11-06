using TheCreators.Enums;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TheCreators.UI
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _pauseMenu;
        public void Pause()
        {
            _pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }

        public void Resume()
        {
            _pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }

        public void Home()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene((int)SceneID.MainMenu);
        }
    }
}