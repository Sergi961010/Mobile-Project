using TheCreators.Managers;
using TheCreators.Persistance;
using UnityEngine;
using UnityEngine.UI;

namespace TheCreators.UI.MainMenu
{
    public class SoundToggle : MonoBehaviour
    {
        [SerializeField] private Sprite soundOn;
        [SerializeField] private Sprite soundOff;
        private Image currentImage;
        private void Awake()
        {
            currentImage = GetComponent<Image>();
        }
        private void Start()
        {
            if (Settings.SoundEnabled) currentImage.sprite = soundOn;
            else currentImage.sprite = soundOff;
        }
        public void OnClick()
        {
            if(Settings.SoundEnabled)
            {
                currentImage.sprite = soundOff;
            } else
            {
                currentImage.sprite = soundOn;
            }
            SoundManager.Instance.ToogleSound();
            Settings.SoundEnabled = !Settings.SoundEnabled;
        }
    }
}