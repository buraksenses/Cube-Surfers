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
        [SerializeField] internal List<Transform> stackableCubes;
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
            for (var ındex = 0; ındex < cubes.Count; ındex++)
            {
                var cube = cubes[ındex];
                cube.ThisTransform.position =
                    new Vector3(lastCubePos.position.x, cube.transform.localScale.y + stackableCubes.Count,
                        lastCubePos.position.z);
                
                stackableCubes.Add(cube.ThisTransform);
                
                cube.Rigidbody.isKinematic = false;
                cube.BoxCollider.isTrigger = false;
                cube.isStacked = true;
                cube.firstCubeTr = lastCubePos;
                
                EventManager.onUpdate += cube.Move;
                EventManager.OnCollectCube();
                EffectManager.Instance.CreateFireworkEffect(cube.ThisTransform.position + Vector3.back);
            }
        }

        private IEnumerator OscillateRoutine()
        {
            for (int i = 0; i < stackableCubes.Count; i++)
            {
                stackableCubes[i].DOPunchScale(new Vector3(.75f, 0, .75f), .4f);
                yield return _waitForSecondsForOscillate;
            }
        }

        public void Unstack(Transform cube)
        {
            stackableCubes.Remove(cube);
            EventManager.onUpdate -= cube.GetComponent<CollectibleCube>().Move;
            
            if (stackableCubes.Count != 0) return;
            EventManager.OnGameOver();
        }
    }
}

