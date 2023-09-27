using UnityEngine;
using UnityEngine.UI;

namespace TheCreators.UI.MainMenu
{
    public class MusicToogle : MonoBehaviour
    {
        [SerializeField] private Sprite soundOn;
        [SerializeField] private Sprite soundOff;
        private int soundState;
        private Image currentImage;
        private void Awake()
        {
            currentImage = GetComponent<Image>();
            soundState = PlayerPrefs.GetInt("soundState", 1);
        }
        private void Start()
        {
            if (soundState == 1) currentImage.sprite = soundOn;
            else currentImage.sprite = soundOff;
        }
        public void OnClick()
        {
            if(soundState == 1)
            {
                currentImage.sprite = soundOff;
                soundState = 0;
            } else
            {
                currentImage.sprite = soundOn;
                soundState = 1;
            }
            PlayerPrefs.SetInt("soundState", soundState);
        }
    }
}