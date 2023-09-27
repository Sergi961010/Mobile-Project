using System;
using UnityEngine;

namespace TheCreators.Managers
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance;
        [SerializeField] private AudioSource _musicSource, _effectsSource;
        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        private void Start()
        {
            int soundState = PlayerPrefs.GetInt("soundState");
            if (soundState == 0) MuteSound();
        }
        private void MuteSound()
        {
            _musicSource.mute = true;
            _effectsSource.mute = true;
        }
        public void ToogleSound()
        {
            _musicSource.mute = !_musicSource.mute;
            _effectsSource.mute = !_effectsSource.mute;
        }
    }
}