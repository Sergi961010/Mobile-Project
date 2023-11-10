using UnityEngine;
using TMPro;
using TheCreators.Utilities;
using TheCreators.Persistance;

namespace TheCreators.UI
{
    [RequireComponent(typeof(TMP_Text))]
    public class Score : MonoBehaviour
    {
        private TMP_Text _textMeshPro;
        private StopwatchTimer _scoreTimer;
        private int _score;
        private void Awake()
        {
            _textMeshPro = GetComponent<TMP_Text>();
            _scoreTimer = new StopwatchTimer();
        }
        private void Start()
        {
            _scoreTimer.Start();
        }
        private void Update()
        {
            _scoreTimer.Tick(Time.deltaTime);
            _score = (int)Mathf.Round(_scoreTimer.GetTime());
            _textMeshPro.text = "Score: " + _score;
        }
        public void ResumeScoring() => _scoreTimer.Resume();
        public void StopScoring() => _scoreTimer.Stop();
        public void StoreHighScore()
        {
            if (Settings.HighScore < _score)
                Settings.HighScore = _score;
        }
    }
}