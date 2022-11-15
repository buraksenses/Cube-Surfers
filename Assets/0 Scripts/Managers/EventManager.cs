using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeSurfers.Managers
{
    public class EventManager : MonoBehaviour
    {
        public static event Action onUpdate, onFixedUpdate;
        public static event Action onCollectCube, onDropCube;
        public static event Action onGameOver;

        private void Update()
        {
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
            onUpdate = null;
            onGameOver?.Invoke();
        }
    }
}

