using UnityEngine;

namespace CubeSurfers.Managers
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioClip collectingSound;
        [SerializeField] private AudioClip gameOverSound;
        [SerializeField] private AudioClip diamondSound;
        [SerializeField] private AudioSource audioSource;

        private void Start()
        {
            EventManager.onCollectCube += PlayCollectSound;
            EventManager.onGameOver += PlayGameOverSound;
            EventManager.onCollectDiamond += PlayDiamondSound;
        }

        private void PlayCollectSound()
        {
            audioSource.PlayOneShot(collectingSound);
        }

        private void PlayGameOverSound()
        {
            audioSource.PlayOneShot(gameOverSound);
        }

        private void PlayDiamondSound()
        {
            audioSource.PlayOneShot(diamondSound);   
        }
    }

}
