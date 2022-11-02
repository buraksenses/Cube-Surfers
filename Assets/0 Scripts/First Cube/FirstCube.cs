using System;
using System.Collections;
using System.Collections.Generic;
using CubeSurfers.Managers;
using CubeSurfers.Movement;
using UnityEngine;

public class FirstCube : MonoBehaviour,ICollectible
{
    private Transform _thisTransform;
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _thisTransform = transform;
        _playerMovement = FindObjectOfType<PlayerMovement>();
    }

    private void Start()
    {
        GetCollected();
        
        //EVENT ASSIGNMENTS
        EventManager.onUpdate += Move;
    }

    public void GetCollected()
    {
        StackManager.Instance.stackableCubes.Add(transform);
    }

    private void Move()
    {
        var position = _playerMovement.transform.position;
        _thisTransform.position = new Vector3(position.x,
            _thisTransform.position.y, position.z);
    }
}
