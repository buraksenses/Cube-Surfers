using System;
using System.Collections;
using System.Collections.Generic;
using CubeSurfers.Managers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CubeSurfers.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        public float leftBounds = -4f;
        public float rightBounds = 4f;

        private float _deltaX;
        private float _moveSensitivity = 600f;

        private Transform _thisTransform;

        private void Start()
        {
            _thisTransform = transform;
            
            //EVENT ASSIGNMENTS
            EventManager.onUpdate += MoveForward;
            EventManager.onUpdate += MoveByBounds;
        }

        private void MoveForward()
        {
            transform.position += Vector3.forward * (Time.deltaTime * 15f);
        }

        private void MoveByBounds()
        {
            var modelPos = _thisTransform.localPosition;


            if (Input.GetMouseButton(0))
            {

                StartCoroutine(MouseXCalculator());

                modelPos.x += _moveSensitivity * _deltaX * Time.deltaTime;
                _thisTransform.localPosition = modelPos;
            }

            modelPos.x = Mathf.Clamp(modelPos.x, leftBounds, rightBounds);
            _thisTransform.localPosition = modelPos;
        }

        private IEnumerator MouseXCalculator()
        {

            var lastPos = Input.mousePosition.x;

            yield return null;

            _deltaX = (Input.mousePosition.x - lastPos) / Screen.width;
        }
    }

}
