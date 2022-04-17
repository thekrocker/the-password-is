using System;
using UnityEngine;

namespace Managers
{
    public class AudioManager : Singleton<AudioManager>
    {
        [SerializeField] private AudioClip folderClickSound;
        [SerializeField] private AudioClip keyboardClickSound;
        [SerializeField] private AudioClip passwordSuccessSound;
        [SerializeField] private AudioClip passwordFailedSound;

        private AudioSource _audioSource;

        private void Start() => _audioSource = GetComponent<AudioSource>();

        public void PlayClickSound()
        {
            if (_audioSource != null)
                _audioSource.PlayOneShot(folderClickSound);
        }

        public bool shouldPlay = true;
        public void PlayKeyboardClickSound()
        {
            if (!shouldPlay) return;
            if (_audioSource != null)
                _audioSource.PlayOneShot(keyboardClickSound);
        }

        public void PlayPasswordSuccess()
        {
            if (_audioSource != null)
                _audioSource.PlayOneShot(passwordSuccessSound);
        }


        public void PlayPasswordFailed()
        {
            if (_audioSource != null)
                _audioSource.PlayOneShot(passwordFailedSound);
        }

        public void SetKeyboardClick() => shouldPlay = !shouldPlay;
    }
}