using TheCreators.Persistance;
using TheCreators.Scripts.ScriptableObjects.Audio;
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
        public void PlayLoopedSound(AudioClip audioClip)
        {
            _effectsSource.clip = audioClip;
            _effectsSource.loop = true;
            _effectsSource.Play();
        }
        public void StopLoopedSound()
        {
            _effectsSource.loop = false;
            _effectsSource.Stop();
        }
        public void PlaySound(AudioClip audioClip)
        {
            _effectsSource.PlayOneShot(audioClip);
        }
        public void PlayAudioEvent(AudioEvent audioEvent)
        {
            audioEvent.Play(_effectsSource);
        }
        public void PlayLoopedAudioEvent(AudioEvent audioEvent)
        {
            _effectsSource.loop = true;
            audioEvent.Play(_effectsSource);
        }
        public void StopLoopedAudioEvent()
        {
            _effectsSource.loop = false;
            _effectsSource.Stop();
        }
    }
}