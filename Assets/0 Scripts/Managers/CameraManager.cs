using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace CubeSurfers.Managers
{
    public class CameraManager : Singleton<CameraManager>
    {
        [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;

        public void AssignFollowObject()
        {
            cinemachineVirtualCamera.Follow = GameObject.FindGameObjectWithTag("FirstCubePos").transform;
        }
    }
}


