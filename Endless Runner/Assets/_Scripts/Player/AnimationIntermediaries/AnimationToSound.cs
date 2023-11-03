using TheCreators.Managers;
using TheCreators.Scripts.ScriptableObjects.Audio;
using UnityEngine;

namespace TheCreators.Player.AnimationIntermediaries
{
    public class AnimationToSound : MonoBehaviour
    {
        public void PlayAudioEvent(AudioEvent audioEvent)
        {
            SoundManager.Instance.PlayAudioEvent(audioEvent);
        }
    }
}
