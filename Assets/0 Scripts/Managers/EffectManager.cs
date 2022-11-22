using System.Collections;
using System.Collections.Generic;
using CubeSurfers.Managers;
using DG.Tweening;
using EZ_Pooling;
using UnityEngine;

namespace CubeSurfers.Managers
{
    public class EffectManager : Singleton<EffectManager>
    {
        [SerializeField] private Transform bubbleEffect;
        [SerializeField] private Transform fireworkEffect;
        [SerializeField] private Transform plusOneEffect;

        public void BubbleLavaEffect(Vector3 pos)
        {
            Transform effectTr = EZ_PoolManager.Spawn(bubbleEffect,pos, Quaternion.identity);
            DOVirtual.DelayedCall(1f, () =>
            {
                EZ_PoolManager.Despawn(effectTr);
            });
        }

        public void CreateFireworkEffect(Vector3 pos)
        {
            Transform effectTr = EZ_PoolManager.Spawn(fireworkEffect,pos, Quaternion.identity);
            DOVirtual.DelayedCall(1f, () =>
            {
                EZ_PoolManager.Despawn(effectTr);
            });
        }

        public void CreatePlusOneEffect(Vector3 pos)
        {
            Transform effectTr = EZ_PoolManager.Spawn(plusOneEffect,pos, Quaternion.identity);
            DOVirtual.DelayedCall(1f, () =>
            {
                EZ_PoolManager.Despawn(effectTr);
            });
        }
        
    }
}


