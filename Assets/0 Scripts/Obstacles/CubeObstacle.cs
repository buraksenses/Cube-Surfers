using CubeSurfers.Collecting;
using CubeSurfers.Managers;
using CubeSurfers.Movement;
using UnityEngine;

public class CubeObstacle : MonoBehaviour,IObstacle
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out CollectibleCube collectableCube))
        {
            Hit(collectableCube.ThisTransform);
        }
        
        else if (collision.collider.TryGetComponent(out StickmanMovement stickmanMovement))
        {
            EventManager.OnGameOver();
        }
    }

    public void Hit(Transform other)
    {
        StackManager.Instance.Unstack(other);
    }
}
