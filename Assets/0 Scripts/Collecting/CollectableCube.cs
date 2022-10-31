using System;
using System.Collections;
using System.Collections.Generic;
using CubeSurfers.Managers;
using CubeSurfers.Movement;
using UnityEngine;

namespace CubeSurfers.Collecting
{
    public class CollectableCube : MonoBehaviour,ICollectible
    {
        private BoxCollider _boxCollider;
        private Rigidbody _rigidbody;
        private void Awake()
        {
            _boxCollider = GetComponent<BoxCollider>();
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out PlayerMovement playerMovement)) return;
            GetCollected();
        }

        public void GetCollected()
        {
            StackManager.Instance.Stack(transform);
            FindObjectOfType<EventManager>().OnCollectCube();
            _boxCollider.isTrigger = false;
            _rigidbody.isKinematic = false;
        }
    }
}

