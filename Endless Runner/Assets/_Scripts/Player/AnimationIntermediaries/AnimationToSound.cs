using TheCreators.CoreSystem.CoreComponents;
using TheCreators.Scripts.ScriptableObjects.Audio;
using UnityEngine;

namespace TheCreators.Player.AnimationIntermediaries
{
    public class AnimationToSound : MonoBehaviour
    {
        [SerializeField] private AudioController _soundController;
        public void PlayAudioEvent(AudioEvent audioEvent)
        {
            _soundController.PlayAudioEvent(audioEvent);
        }
    }
}
