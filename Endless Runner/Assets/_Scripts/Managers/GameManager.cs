using UnityEngine;

namespace TheCreators.Managers
{
    public class GameManager : MonoBehaviour
    {
        private void OnEnable()
        {
            Application.targetFrameRate = 60;
        }
        public void Pause()
        {
            Time.timeScale = 0f;
        }
        public void Resume()
        {
            Time.timeScale = 1f;
        }
    }
}