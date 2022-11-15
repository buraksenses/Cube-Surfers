using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeSurfers.Managers
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioClip collectingSound;
        [SerializeField] private AudioClip gameOverSound;
        [SerializeField] private AudioSource audioSource;

        private void Start()
        {
            EventManager.onCollectCube += PlayCollectSound;
            EventManager.onGameOver += PlayGameOverSound;
        }

        private void PlayCollectSound()
        {
            audioSource.PlayOneShot(collectingSound);
        }

        private void PlayGameOverSound()
        {
            audioSource.PlayOneShot(gameOverSound);
        }
    }

}
