using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeSurfers.Managers
{
    public class StackManager : Singleton<StackManager>
    {
        public List<Transform> stackableCubes;
        private FirstCube _firstCube;

        private void Start()
        {
            _firstCube = FindObjectOfType<FirstCube>();
            stackableCubes.Add(_firstCube.transform);
        }

        public void Stack(Transform cube)
        {
            stackableCubes.Add(cube);
        }
    }
}

