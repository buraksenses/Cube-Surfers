using System;
using System.Collections;
using System.Collections.Generic;
using CubeSurfers.Collecting;
using UnityEngine;
using DG.Tweening;
using UnityEditor;

namespace CubeSurfers.Managers
{
    public class StackManager : Singleton<StackManager>
    {
        public List<Transform> stackableCubes;
        private readonly float _cubeScale = 0.5f;
        private Transform lastCubePos;

        private void Start()
        {
            lastCubePos = GameObject.FindGameObjectWithTag("FirstCubePos").transform;
        }

        public void Stack(Transform cube)
        {
            if(!cube.CompareTag("First Cube"))
                cube.position = 
                    new Vector3(lastCubePos.position.x, lastCubePos.position.y + ((cube.transform.localScale.y + .5f) * stackableCubes.Count), lastCubePos.position.z);
            stackableCubes.Add(cube);

            //StartCoroutine(OscillateRoutine());
        }

        private IEnumerator OscillateRoutine()
        {
            for (int i = 0; i < stackableCubes.Count; i++)
            {
                stackableCubes[i].DOPunchScale(new Vector3(.06f, 0, .06f), .3f);
                yield return new WaitForSeconds(.1f);
            }
        }

        public void Unstack(Transform cube)
        {
            stackableCubes.Remove(transform);
            EventManager.onUpdate -= cube.GetComponent<CollectableCube>().Move;
        }
    }
}

