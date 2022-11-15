using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeSurfers.Managers
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioClip collectingSound;
        [SerializeField] private AudioSource audioSource;

        private void Start()
        {
            EventManager.onCollectCube += PlayCollectSound;
        }

        private void PlayCollectSound()
        {
            audioSource.PlayOneShot(collectingSound);
        }
    }

}
