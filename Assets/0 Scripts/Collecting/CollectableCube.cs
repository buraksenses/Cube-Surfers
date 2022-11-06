using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using CubeSurfers.Managers;
using CubeSurfers.Movement;
using UnityEngine;
using DG.Tweening;

namespace CubeSurfers.Collecting
{
    public class CollectableCube : MonoBehaviour,ICollectible
    {
        private BoxCollider _boxCollider;
        private Rigidbody _rigidbody;
        internal Transform ThisTransform;
        [SerializeField] private Transform firstCubeTr;
        [SerializeField] private bool isStacked;
        [SerializeField] private float timeScale = 1;
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
            if (!other.TryGetComponent(out ICollectible collectible)) return;
            GetCollected();
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
            FindObjectOfType<EventManager>().OnCollectCube();
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

