using UnityEngine;

namespace TheCreators.Player.Controllers
{
    public class SoundController : MonoBehaviour
    {
        [SerializeField] private AudioClip _footstepClip;
        private AudioSource _audioSource;
        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }
        public void PlayFootstep()
        {
            _audioSource.clip = _footstepClip;
            _audioSource.Play();
        }
    }
}