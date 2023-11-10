using TheCreators.Persistance;
using TMPro;
using UnityEngine;

namespace TheCreators.UI.MainMenu
{
    [RequireComponent(typeof(TMP_Text))]
    public class DisplayHighScore : MonoBehaviour
    {
        private TMP_Text _textMeshPro;
        private void Awake()
        {
            _textMeshPro = GetComponent<TMP_Text>();
        }
        private void Start()
        {
            _textMeshPro.text = ($"High Score: {Settings.HighScore}");
        }
    }
}
