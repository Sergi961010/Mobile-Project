using UnityEngine;

namespace TheCreators.Scripts.ScriptableObjects.Audio
{
	public abstract class AudioEvent : ScriptableObject
	{
		public abstract void Play(AudioSource source);
	}
}