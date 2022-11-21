using System;
using UnityEngine;

namespace CubeSurfers.Managers
{
    [CreateAssetMenu(fileName = "Game Data",menuName = "Game Data")]
    public class DataManager : ScriptableObject
    {
        public int Gem { get; private set; }
        public Color cubeColor;

        private void OnEnable()
        {
            EventManager.onCollectDiamond += IncreaseGemCount;
        }

        private void IncreaseGemCount()
        {
            Gem++;
        }
    }
}

