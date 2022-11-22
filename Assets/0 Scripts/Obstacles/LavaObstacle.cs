using CubeSurfers.Collecting;
using CubeSurfers.Managers;
using CubeSurfers.Movement;
using DG.Tweening;
using UnityEngine;

namespace CubeSurfers.Obstacles
{
    public class LavaObstacle : MonoBehaviour,IObstacle
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out CollectibleCube collectableCube))
            {
                Hit(collectableCube.ThisTransform);
            }
            else if (other.TryGetComponent(out RagdollToggle ragdollToggle))
            {
                ragdollToggle.RagdollActivate(true);
            }
        }

        public void Hit(Transform other)
        {
            StackManager.Instance.Unstack(other);
            EffectManager.Instance.BubbleLavaEffect(other.position);
            other.GetComponent<BoxCollider>().isTrigger = true;
            other.GetComponent<Rigidbody>().drag = 10;

            DOVirtual.DelayedCall(3f, () =>
            {
                Destroy(other.gameObject);
            });
        
        }
    
    }
}

