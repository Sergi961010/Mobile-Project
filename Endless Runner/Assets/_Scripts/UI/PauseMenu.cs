using TheCreators.Enums;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace TheCreators.UI
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _pauseMenu;
        [SerializeField] private UnityEvent _onPause;
        [SerializeField] private UnityEvent _onResume;
        public void Pause()
        {
            _pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            _onPause.Invoke();
        }

        public void Resume()
        {
            _pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            _onResume.Invoke();
        }

        public void Home()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene((int)SceneID.MainMenu);
        }
    }
}