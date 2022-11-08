using System;
using System.Collections;
using System.Collections.Generic;
using CubeSurfers.Collecting;
using CubeSurfers.Managers;
using CubeSurfers.Movement;
using DG.Tweening;
using UnityEngine;

public class LavaObstacle : MonoBehaviour,IObstacle
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CollectibleCube collectableCube))
        {
            Hit(collectableCube.ThisTransform);
        }
        else if (other.TryGetComponent(out StickmanMovement stickmanMovement))
        {
            stickmanMovement.GetComponent<CapsuleCollider>().isTrigger = true;
            stickmanMovement.GetComponent<Rigidbody>().drag = 10;
            EventManager.Instance.OnGameOver();
        }
    }

    public void Hit(Transform other)
    {
        StackManager.Instance.Unstack(other);
        other.GetComponent<BoxCollider>().isTrigger = true;
        
        DOVirtual.DelayedCall(2f, () =>
        {
            Destroy(other.gameObject);
        });
        
    }
    
}
