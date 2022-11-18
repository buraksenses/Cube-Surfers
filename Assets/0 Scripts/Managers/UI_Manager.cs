using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CubeSurfers.Managers
{
    public class UI_Manager : MonoBehaviour
    {
        [SerializeField] private GameObject losePanel;
        [SerializeField] private GameObject winPanel;
        [SerializeField] private Transform tapToStartButton;

        private void Start()
        {
            tapToStartButton.gameObject.SetActive(true);
            Vector3 scaleVector = new Vector3(1.1f,1,1);
            tapToStartButton.DOScale(scaleVector, 1f).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.Linear);
            
            //===== EVENT ASSIGNMENTS =====

            EventManager.onGameOver += OnFail;
            EventManager.onSuccess += OnSuccess;
        }

        private void OnFail()
        {
            losePanel.SetActive(true);
        }

        private void OnSuccess()
        {
            winPanel.SetActive(true);
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

        #endregion
    }
}

