using System;
using UnityEngine;

namespace CubeSurfers.Managers
{
    public class EventManager : MonoBehaviour
    {
        public static event Action onUpdate, onFixedUpdate;
        public static event Action onCollectCube, onDropCube,onCollectDiamond;
        public static event Action onGameOver,onSuccess;
        
        private static void ResetValues()
        {
            onSuccess = null;
            onUpdate = null;
            onCollectCube = null;
            onDropCube = null;
            onFixedUpdate = null;
            onGameOver = null;
        }

        private void Update()
        {
            if (!GameManager.isGameOver && !GameManager.isGameStarted) return;
            onUpdate?.Invoke();
        }

        private void FixedUpdate()
        {
            onFixedUpdate?.Invoke();
        }

        public static void OnCollectCube()
        {
            onCollectCube?.Invoke();
        }

        public static void OnDropCube()
        {
            onDropCube?.Invoke();
        }

        public static void OnGameOver()
        {
            onGameOver?.Invoke();
            ResetValues();
        }

        public static void OnSuccess()
        {
            onSuccess?.Invoke();
        }

        public static void OnCollectDiamond()
        {
            onCollectDiamond?.Invoke();
        }
        
    }
}

