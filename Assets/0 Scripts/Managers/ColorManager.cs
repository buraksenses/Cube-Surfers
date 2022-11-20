using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CubeSurfers.Collecting;
using UnityEngine;

namespace CubeSurfers.Managers
{
    public class ColorManager : MonoBehaviour
    {
        private  List<CollectibleCube> _collectibleCubes;
        private static List<MeshRenderer> _cubeMeshRenderers = new List<MeshRenderer>();

        private void Awake()
        {
            _collectibleCubes = FindObjectsOfType<CollectibleCube>().ToList();

            foreach (var collectibleCube in _collectibleCubes)
            {
                _cubeMeshRenderers.Add(collectibleCube.GetComponent<MeshRenderer>());
            }
        }

        public static void ChangeColor(Color color)
        {
            foreach (var cubeMeshRenderer in _cubeMeshRenderers)
            {
                cubeMeshRenderer.sharedMaterial.color = color;
            }
        }
   
    }
}

