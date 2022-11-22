using System;
using System.Collections;
using System.Collections.Generic;
using CubeSurfers.Managers;
using UnityEngine;

namespace CubeSurfers.Movement
{
    public class RagdollToggle : MonoBehaviour
    {
        public Animator animator;
        [SerializeField] private Rigidbody Rigidbody;
        [SerializeField] private CapsuleCollider capsuleCollider;
        private Collider[] childrenCollider;
        private Rigidbody[] childrenRigidbody;
        public Transform pelvisTr;
        private Rigidbody pelvisRb;

        public void Start()
        {
            childrenCollider = pelvisTr.GetComponentsInChildren<Collider>();
            childrenRigidbody = pelvisTr.GetComponentsInChildren<Rigidbody>();
            pelvisRb = pelvisTr.GetComponent<Rigidbody>();

            RagdollActivate(false);
        }

        private void GameRestarted()
        {
            RagdollActivate(false);
        }

        public void AddForceToPelvis(Vector3 force)
        {
            pelvisRb.AddForce(force, ForceMode.Impulse);
        }

        public void RagdollActivate(bool active)
        {
            //children
            foreach (var collider in childrenCollider)
                collider.enabled = active;
            foreach (var rigidb in childrenRigidbody)
            {
                rigidb.detectCollisions = active;
                rigidb.isKinematic = !active;
            }

            //rest
            animator.enabled = !active;
            Rigidbody.detectCollisions = !active;
            Rigidbody.isKinematic = active;
            capsuleCollider.enabled = !active;
            //script.enabled = !active;
        }
    }
}