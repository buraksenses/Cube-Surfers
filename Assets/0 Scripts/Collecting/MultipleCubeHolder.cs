using System;
using System.Collections;
using System.Collections.Generic;
using CubeSurfers.Collecting;
using CubeSurfers.Managers;
using UnityEngine;

namespace CubeSurfers.Collecting
{
    public class MultipleCubeHolder : MonoBehaviour
    {
        [SerializeField] private List<CollectibleCube> connectedCubes;
        private Transform _thisTransform;
        private bool _isCollected;
        
        public int connectedCubeNumber;
        
        private void Start()
        {
            StackMultipleCubesOnStart();
        }

        private void StackMultipleCubesOnStart()
        {
            _thisTransform = transform;
        
            for (int i = 0; i < connectedCubeNumber; i++)
            {
                CollectibleCube cube = Instantiate(StackManager.Instance.spawnableCubePrefab);
                connectedCubes.Add(cube);
                cube.ThisTransform.position = new Vector3(_thisTransform.position.x,
                    _thisTransform.position.y + i + 1, _thisTransform.position.z);
                cube.firstCubeTr = GameObject.FindGameObjectWithTag("FirstCubePos").transform;
            }
        }

        public void OnCollectMultipleCubes()
        {
            if(!_isCollected)
                StackManager.Instance.StackMultipleCubes(connectedCubes);
            _isCollected = true;
        }
    }
}

