using TheCreators.Scripts.ScriptableObjects.Audio;
using UnityEngine;

namespace TheCreators.Player.Controllers
{
    public class AudioController : MonoBehaviour
    {
        [SerializeField] private SimpleAudioEvent _footstep;
        private AudioSource _audioSource;
        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }
        public void PlayFootstep()
        {
            _footstep.Play(_audioSource);
        }
    }
}