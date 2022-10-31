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

        private void Update()
        {
            onUpdate?.Invoke();
        }

        private void FixedUpdate()
        {
            onFixedUpdate?.Invoke();
        }

        public void OnCollectCube()
        {
            onCollectCube?.Invoke();
        }

        public void OnDropCube()
        {
            onDropCube?.Invoke();
        }
    }
}

