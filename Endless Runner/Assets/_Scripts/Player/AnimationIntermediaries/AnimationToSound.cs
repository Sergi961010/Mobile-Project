using TheCreators.Player.Controllers;
using UnityEngine;

namespace TheCreators.Player.AnimationIntermediaries
{
    public class AnimationToSound : MonoBehaviour
    {
        private AudioController _soundController;
        private void Awake()
        {
            _soundController = GetComponentInChildren<AudioController>();
        }
        public void PlayFootstep()
        {
            _soundController.PlayFootstep();
        }
    }
}
