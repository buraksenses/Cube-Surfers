using System;
using System.Collections;
using System.Collections.Generic;
using CubeSurfers.Managers;
using UnityEngine;

namespace CubeSurfers.Movement
{
    public class StickmanMovement : MonoBehaviour
    {
        
        private void Start()
        {
            // EVENT ASSIGNMENTS
            EventManager.onCollectCube += Jump;
        }

        private void Jump()
        {
            transform.position = new Vector3(transform.position.x,
                StackManager.Instance.stackableCubes[StackManager.Instance.stackableCubes.Count - 1].transform
                    .position.y + .02f,transform.position.z);
        }
    }
}

