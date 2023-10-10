using TheCreators.Scripts.ScriptableObjects.Audio;
using UnityEngine;

namespace TheCreators.CoreSystem.CoreComponents
{
    public class AudioController : BaseCoreComponent
    {
        [SerializeField] private SimpleAudioEvent _footstep;
        private AudioSource _audioSource;
        protected override void Awake()
        {
            base.Awake();
            _audioSource = GetComponentInParent<AudioSource>();
        }
        public void PlayFootstep()
        {
            _footstep.Play(_audioSource);
        }
    }
}