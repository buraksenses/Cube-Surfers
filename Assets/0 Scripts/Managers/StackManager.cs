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
        internal Transform lastCubePos;
        private readonly WaitForSeconds _waitForSecondsForOscillate = new WaitForSeconds(.05f);

        public CollectibleCube spawnableCubePrefab;

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

        public void StackMultipleCubes(List<CollectibleCube> cubes)
        {
            foreach (var cube in cubes)
            {
                cube.ThisTransform.position = 
                    new Vector3(lastCubePos.position.x, cube.transform.localScale.y + stackableCubes.Count, lastCubePos.position.z);
                stackableCubes.Add(cube.ThisTransform);
                cube._rigidbody.isKinematic = false;
                cube._boxCollider.isTrigger = false;
                cube.isStacked = true;
                cube.firstCubeTr = lastCubePos;
                EventManager.onUpdate += cube.Move;
                cube.transform.localScale = Vector3.one;
                EventManager.Instance.OnCollectCube();
            }
        }

        private IEnumerator OscillateRoutine()
        {
            for (int i = 0; i < stackableCubes.Count; i++)
            {
                stackableCubes[i].DOPunchScale(new Vector3(1f, 0, 1f), .2f);
                yield return _waitForSecondsForOscillate;
            }
        }

        public void Unstack(Transform cube)
        {
            stackableCubes.Remove(cube);
            EventManager.onUpdate -= cube.GetComponent<CollectibleCube>().Move;
            if(stackableCubes.Count == 0)
                EventManager.Instance.OnGameOver();
        }
    }
}

