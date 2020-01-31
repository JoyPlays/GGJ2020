using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ugitty.Audio;

namespace Ugitty.Components
{
    public class AudioCompositionPlayer : MonoBehaviour
    {
        [SerializeField]
        private AudioSource audioSource;
        [SerializeField]
        private AudioComposition composition;

        public void Play()
        {
            composition.Play(audioSource);
        }
    }
}