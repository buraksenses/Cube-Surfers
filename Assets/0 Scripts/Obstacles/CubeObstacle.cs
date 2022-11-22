using CubeSurfers.Collecting;
using CubeSurfers.Managers;
using CubeSurfers.Movement;
using UnityEngine;

namespace CubeSurfers.Obstacles
{
    public class CubeObstacle : MonoBehaviour,IObstacle
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.TryGetComponent(out CollectibleCube collectableCube))
            {
                Hit(collectableCube.ThisTransform);
            }
        
            else if (collision.collider.TryGetComponent(out RagdollToggle ragdollToggle))
            {
                EventManager.OnGameOver();
                ragdollToggle.RagdollActivate(true);
                ragdollToggle.AddForceToPelvis(Vector3.back * 2f);

            }
        }

        public void Hit(Transform other)
        {
            StackManager.Instance.Unstack(other);
        }
    }

}
