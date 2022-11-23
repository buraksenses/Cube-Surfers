using CubeSurfers.Managers;
using DG.Tweening;
using UnityEngine;

namespace CubeSurfers.Collecting
{
    public class CollectibleDiamond : MonoBehaviour,ICollectible
    {
        private Camera _mainCamera;
        private RectTransform _desiredPos;
        [SerializeField] private RectTransform collectedDiamondPrefab;

        private void Start()
        {
            _mainCamera = Camera.main;
            _desiredPos = GameObject.FindGameObjectWithTag("GemPanel").GetComponent<RectTransform>();
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
            RectTransform rectTransform = Instantiate(collectedDiamondPrefab, screenPoint,Quaternion.identity,_desiredPos);
            rectTransform.DOMove(_desiredPos.position, .5f).SetEase(Ease.InBack).OnComplete(() =>
            {
                Destroy(rectTransform.gameObject); 
                _desiredPos.transform.GetChild(0).DOPunchScale(Vector3.one * 1.01f, .025f);
            });
            gameObject.SetActive(false);
        }
    }
}

