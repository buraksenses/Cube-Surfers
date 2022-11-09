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
        internal BoxCollider _boxCollider;
        internal Rigidbody _rigidbody;
        internal Transform ThisTransform;
        [SerializeField,CanBeNull] internal Transform firstCubeTr;
        [SerializeField] internal bool isStacked;
        [SerializeField] private float timeScale = 1;
        public bool isCollectible = true;

        private void Awake()
        {
            _boxCollider = GetComponent<BoxCollider>();
            _rigidbody = GetComponent<Rigidbody>();
            ThisTransform = transform;
        }

        private void Start()
        {
            if (!CompareTag("First Cube")) return;
            StackManager.Instance.Stack(ThisTransform);
            EventManager.onUpdate += Move;
            isStacked = true;
        }

        private void Update()
        {
            Time.timeScale = timeScale;
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

        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.collider.CompareTag("Obstacle")) return;
            StackManager.Instance.Unstack(ThisTransform);
            isStacked = false;
            Debug.Log(name);
        }

        public void GetCollected()
        {
            if (isStacked) return;
            StackManager.Instance.Stack(transform);
            EventManager.Instance.OnCollectCube();
            _boxCollider.isTrigger = false;
            _rigidbody.isKinematic = false;
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

