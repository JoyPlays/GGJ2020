using UnityEngine;
using Ugitty.Audio;

namespace Ugitty.Components
{
    public class AudioCompositionPlayer : MonoBehaviour
    {
        public AudioSource audioSource;
        public AudioComposition composition;

        public void Play()
        {
            if (audioSource == null)
            {
                Debug.LogError("Missing audio source for " + this.name);
                return;
            }

            if (composition == null)
            {
                Debug.LogWarning("Missing audio composition for " + this.name);
                return;
            }

            composition.Play(audioSource);
        }
    }
}