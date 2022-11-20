using System;
using UnityEngine;

namespace CubeSurfers.Managers
{
    [CreateAssetMenu(fileName = "Game Data",menuName = "Game Data")]
    public class DataManager : ScriptableObject
    {
        public int gem;
        public Color cubeColor;

        public void IncreaseGemCount()
        {
            gem++;
        }
    }
}

