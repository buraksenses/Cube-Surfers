using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using CubeSurfers.Managers;
using CubeSurfers.Movement;
using UnityEngine;
using DG.Tweening;
using JetBrains.Annotations;

namespace CubeSurfers.Collecting
{
    public class CollectibleCube : MonoBehaviour,ICollectible
    {
        internal BoxCollider BoxCollider;
        internal Rigidbody Rigidbody;
        internal Transform ThisTransform;
        
        [SerializeField,CanBeNull] internal Transform firstCubeTr;
        [SerializeField] internal bool isStacked;
        
        public bool isCollectible = true;

        private void Awake()
        {
            BoxCollider = GetComponent<BoxCollider>();
            Rigidbody = GetComponent<Rigidbody>();
            ThisTransform = transform;
        }

        private void Start()
        {
            if (!CompareTag("First Cube")) return;
            StackManager.Instance.Stack(ThisTransform);
            EventManager.onUpdate += Move;
            isStacked = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!isCollectible) return;
            if (!other.TryGetComponent(out ICollectible collectible) || other.CompareTag("Spawnable Cube")) return;
            GetCollected();
            
            if (TryGetComponent(out MultipleCubeHolder multipleCubeHolder))
            {
                multipleCubeHolder.OnCollectMultipleCubes();
            }
        }

        public void GetCollected()
        {
            if (isStacked) return;
            StackManager.Instance.Stack(transform);
            EventManager.OnCollectCube();
            BoxCollider.isTrigger = false;
            Rigidbody.isKinematic = false;
            EventManager.onUpdate += Move;
            isStacked = true;
        }

        internal void Move()
        {
            ThisTransform.position =
                new Vector3(firstCubeTr.position.x, ThisTransform.position.y, firstCubeTr.position.z);
        }
    }
}

