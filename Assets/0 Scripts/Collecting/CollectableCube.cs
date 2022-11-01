using System;
using System.Collections;
using System.Collections.Generic;
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
        private Transform _thisTransform;
        private Transform _connectedNode;

        public bool isStacked = false;
        private readonly float _cubeScale = .04f;
        
        private void Awake()
        {
            _boxCollider = GetComponent<BoxCollider>();
            _rigidbody = GetComponent<Rigidbody>();
            _thisTransform = transform;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out PlayerMovement playerMovement)) return;
            GetCollected();
        }

        public void GetCollected()
        {
            FindObjectOfType<EventManager>().OnCollectCube();
            
            _connectedNode = StackManager.Instance.stackableCubes[StackManager.Instance.stackableCubes.Count - 1];
            StackManager.Instance.Stack(transform);
            
            _boxCollider.isTrigger = false;
            _rigidbody.isKinematic = false;
            isStacked = true;
            
            EventManager.onUpdate += Move;
        }

        private void Move()
        {
            var position = _connectedNode.position;
            _thisTransform.position = new Vector3(position.x, position.y + _cubeScale,
                position.z);
        }

    }
}

