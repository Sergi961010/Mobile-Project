using System;
using TheCreators.Persistance;
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
            }
            else
            {
                Destroy(gameObject);
            }
        }
        private void Start()
        {
            if (!Settings.SoundEnabled) MuteSound();
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