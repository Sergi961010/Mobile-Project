using TheCreators.CoreSystem.CoreComponents;
using UnityEngine;

namespace TheCreators.Player.AnimationIntermediaries
{
    public class AnimationToSound : MonoBehaviour
    {
        [SerializeField] private AudioController _soundController;
        public void PlayFootstep()
        {
            _soundController.PlayFootstep();
        }
    }
}
