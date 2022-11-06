using System;
using System.Collections;
using System.Collections.Generic;
using CubeSurfers.Collecting;
using CubeSurfers.Managers;
using UnityEngine;

public class LavaObstacle : MonoBehaviour,IObstacle
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out CollectibleCube collectableCube)) return;
        Hit(collectableCube.ThisTransform);
    }

    public void Hit(Transform other)
    {
        StackManager.Instance.Unstack(other);
    }
}
