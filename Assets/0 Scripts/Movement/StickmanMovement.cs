using System;
using System.Collections;
using System.Collections.Generic;
using CubeSurfers.Managers;
using UnityEngine;

namespace CubeSurfers.Movement
{
    public class StickmanMovement : MonoBehaviour
    {
        private Transform _thisTransform;
        private void Awake()
        {
            _thisTransform = transform;
            
            // EVENT ASSIGNMENTS
            EventManager.onCollectCube += Jump;
        }

        private void Jump()
        {
            _thisTransform.position =
                StackManager.Instance.stackableCubes[StackManager.Instance.stackableCubes.Count - 1].transform
                    .position + Vector3.up * .02f;
        }
    }
}

