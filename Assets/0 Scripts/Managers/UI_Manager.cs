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

        [SerializeField] internal GameObject[] levelPrefabs; 

        [Header("Script References"), Space(20)] [SerializeField]
        private GameSaveManager gameSaveManager;

        private void Start()
        {
            tapToStartButton.gameObject.SetActive(true);
            Vector3 scaleVector = new Vector3(1.1f,1,1);
            tapToStartButton.DOScale(scaleVector, 1f).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.Linear);
            txtGemCount.text = gameSaveManager.gameData.gem.ToString();

            //===== EVENT ASSIGNMENTS =====

            EventManager.onGameOver += OnFail;
            EventManager.onSuccess += OnSuccess;
            EventManager.onCollectDiamond += OnCollectDiamond;
        }

        private void OnFail()
        {
            DOVirtual.DelayedCall(2f,() =>
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
                txtGemCount.text = gameSaveManager.gameData.gem.ToString();
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
            gameSaveManager.gameData.cubeColor = FindObjectOfType<ColorPaletteController>().pickedColorImage.color;
            CameraManager.Instance.AssignFollowObject();
            mainMenu.SetActive(false);
        }

        public void NextButtonOnClick()
        {
            gameSaveManager.gameData.levelCount++;
            gameSaveManager.SaveGame();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        #endregion
    }
}

