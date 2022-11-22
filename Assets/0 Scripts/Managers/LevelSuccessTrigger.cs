using System;
using System.Collections;
using System.Collections.Generic;
using CubeSurfers.Collecting;
using UnityEngine;

namespace CubeSurfers.Managers
{
    public class LevelSuccessTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out CollectibleCube collectibleCube)) return;
            EventManager.OnSuccess();
        }
    }
}


