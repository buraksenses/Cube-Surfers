using CubeSurfers.Managers;
using DG.Tweening;
using UnityEngine;

namespace CubeSurfers.Collecting
{
    public class CollectibleDiamond : MonoBehaviour,ICollectible
    {
        private Camera _mainCamera;
        [SerializeField] private RectTransform desiredPos;
        [SerializeField] private RectTransform collectedDiamondPrefab;

        private void Start()
        {
            _mainCamera = Camera.main;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out CollectibleCube collectibleCube)) return;
            GetCollected();
            EventManager.OnCollectDiamond();
            
        }

        public void GetCollected()
        {
            Vector3 screenPoint = _mainCamera.WorldToScreenPoint(transform.position);
            RectTransform rectTransform = Instantiate(collectedDiamondPrefab, screenPoint,Quaternion.identity,desiredPos);
            
            rectTransform.DOMove(desiredPos.position, 1f).SetEase(Ease.InBack).OnComplete(() =>
            {
                Destroy(rectTransform.gameObject);
                desiredPos.DOPunchScale(Vector3.one * 1.05f, .4f);
            });
            gameObject.SetActive(false);
        }
    }
}

