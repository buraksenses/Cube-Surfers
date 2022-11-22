using UnityEngine;

namespace CubeSurfers.Managers
{
    [System.Serializable]
    public class DataManager
    {
        public int gem;
        public Color cubeColor;
        public int levelCount;

        public void IncreaseGemCount()
        {
            gem++;
        }
    }
}

