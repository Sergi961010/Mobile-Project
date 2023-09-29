using TheCreators.Player.Controllers;
using UnityEngine;

namespace TheCreators.Player.AnimationIntermediaries
{
    public class AnimationToSound : MonoBehaviour
    {
        private SoundController _soundController;
        private void Awake()
        {
            _soundController = GetComponentInChildren<SoundController>();
        }
        public void PlayFootstep()
        {
            _soundController.PlayFootstep();
        }
    }
}
