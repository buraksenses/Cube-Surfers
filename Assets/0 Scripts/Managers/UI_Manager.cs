using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UniRx.Triggers;

namespace CubeSurfers.Managers
{
    public class UI_Manager : MonoBehaviour
    {
        [SerializeField] private GameObject losePanel;
        [SerializeField] private GameObject winPanel;
        [SerializeField] private Transform tapToStartButton;
        [SerializeField] private TMP_Text txtGemCount;
        [SerializeField] private GameObject mainMenu;

        [Header("Scriptable Object References")] [SerializeField]
        private DataManager gameData;

        private void Start()
        {
            tapToStartButton.gameObject.SetActive(true);
            Vector3 scaleVector = new Vector3(1.1f,1,1);
            tapToStartButton.DOScale(scaleVector, 1f).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.Linear);
            txtGemCount.text = gameData.Gem.ToString();

            //===== EVENT ASSIGNMENTS =====

            EventManager.onGameOver += OnFail;
            EventManager.onSuccess += OnSuccess;
            EventManager.onCollectDiamond += OnCollectDiamond;
            
            // ===== ON CLICK EVENT ASSIGNMENTS =====
        }

        private void OnFail()
        {
            DOVirtual.DelayedCall(1f,() =>
            {
                losePanel.SetActive(true);
            });
            
        }

        private void OnSuccess()
        {
            winPanel.SetActive(true);
        }

        private void OnCollectDiamond()
        {
            DOVirtual.DelayedCall(1f, () =>
            {
                txtGemCount.text = gameData.Gem.ToString();
            });

        }

        #region Button Functions

        public void TapToStartButtonOnClick()
        {
            GameManager.isGameStarted = true;
            tapToStartButton.gameObject.SetActive(false);
        }

        public void RetryButtonOnClick()
        {
            GameManager.ResetValues();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//TODO: level prefableri yüklenecek.
        }

        public void StartButton()
        {
            gameData.cubeColor = FindObjectOfType<ColorPaletteController>().pickedColorImage.color;
            mainMenu.SetActive(false);
        }

        #endregion
    }
}

