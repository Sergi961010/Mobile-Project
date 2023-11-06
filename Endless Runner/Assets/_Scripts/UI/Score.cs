using UnityEngine;
using TMPro;
using TheCreators.Utilities;

namespace TheCreators.UI
{
    [RequireComponent(typeof(TMP_Text))]
    public class Score : MonoBehaviour
    {
        private TMP_Text _textMeshPro;
        private StopwatchTimer _scoreTimer;
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
            _textMeshPro.text = "Score: " + Mathf.Round(_scoreTimer.GetTime());
        }
        public void StopScoring() => _scoreTimer.Stop();
    }
}