using UnityEngine;
using TMPro;

namespace TheCreators.UI
{
    [RequireComponent(typeof(TMP_Text))]
    public class Score : MonoBehaviour
    {
        private TMP_Text _textMeshPro;
        private float score = 0;
        private void Awake()
        {
            _textMeshPro = GetComponent<TMP_Text>();
        }
        private void Update()
        {
            score += Time.deltaTime;
            _textMeshPro.text = "Score: " + Mathf.Round(score);

        }
    }
}
