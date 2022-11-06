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
        private readonly float _cubeScale = 0.5f;//TODO: LocalScale olarak değiştirilecek.
        private Transform lastCubePos;
        private readonly WaitForSeconds _waitForSecondsForOscillate = new WaitForSeconds(.05f);

        private void Start()
        {
            lastCubePos = GameObject.FindGameObjectWithTag("FirstCubePos").transform;
        }

        public void Stack(Transform cube)
        {
            if (!cube.CompareTag("First Cube"))
            {
                cube.position = 
                    new Vector3(lastCubePos.position.x, cube.transform.localScale.y + stackableCubes.Count, lastCubePos.position.z);
                StartCoroutine(OscillateRoutine());
            }
                
            stackableCubes.Add(cube);

            
        }

        private IEnumerator OscillateRoutine()
        {
            for (int i = 0; i < stackableCubes.Count; i++)
            {
                stackableCubes[i].DOPunchScale(new Vector3(1f, 0, 1.1f), .4f);
                yield return _waitForSecondsForOscillate;
            }
        }

        public void Unstack(Transform cube)
        {
            stackableCubes.Remove(cube);
            EventManager.onUpdate -= cube.GetComponent<CollectibleCube>().Move;
        }
    }
}

