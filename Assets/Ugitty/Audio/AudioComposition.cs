using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ugitty.Audio
{
    [CreateAssetMenu(fileName = "New audio composition", menuName = "Ugitty/Audio/Audio Composition")]
    public class AudioComposition : ScriptableObject
    {
		public AudioClip[] clips;

		[Range(0f, 100f)]
		public float volume;

		[Range(.1f, 3f)]
		public float pitch;

		public void Play(AudioSource source)
		{
			if (clips.Length == 0) return;

			source.clip = clips[Random.Range(0, clips.Length)];
			source.volume = volume;
			source.pitch = pitch;
			source.Play();
		}
	}
}