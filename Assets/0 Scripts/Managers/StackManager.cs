using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeSurfers.Managers
{
    public class StackManager : Singleton<StackManager>
    {
        public List<Transform> stackableCubes;
        private readonly float _cubeScale = .04f;
        private FirstCube _firstCube;

        private void Start()
        {
            _firstCube = FindObjectOfType<FirstCube>();
            stackableCubes.Add(_firstCube.transform);
        }

        public void Stack(Transform cube)
        {
            Vector3 lastCubePos = stackableCubes[stackableCubes.Count - 1].position;
            stackableCubes.Add(cube);
            //cube.SetParent(_firstCube.transform);//TODO : SetParent yapılmayacak. transform.position ile yapılacak.
            cube.position = new Vector3(lastCubePos.x, lastCubePos.y + _cubeScale, lastCubePos.z);
        }
    }
}

