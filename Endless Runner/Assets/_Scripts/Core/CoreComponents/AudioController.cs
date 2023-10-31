using TheCreators.Scripts.ScriptableObjects.Audio;
using UnityEngine;

namespace TheCreators.CoreSystem.CoreComponents
{
    public class AudioController : BaseCoreComponent
    {
        private AudioSource _audioSource;
        protected override void Awake()
        {
            base.Awake();
            _audioSource = GetComponentInParent<AudioSource>();
        }
        public void PlayAudioEvent(AudioEvent audioEvent)
        {
            audioEvent.Play(_audioSource);
        }
    }
}