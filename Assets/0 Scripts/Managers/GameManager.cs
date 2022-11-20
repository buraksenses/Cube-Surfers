using UnityEngine;

namespace CubeSurfers.Managers
{
    public class GameManager
    {
        public static bool isGameOver = false;
        public static bool isGameStarted = false;
        private static int gemCount;

        public static int GemCount => gemCount;

        public static void ResetValues()
        {
            isGameOver = false;
            isGameStarted = false;
            gemCount = 0;
        }

        public static int IncreaseGemCount()
        {
            gemCount++;
            return gemCount;
        }

        public static void SaveGame()
        {
            PlayerPrefs.SetInt("Gem",gemCount);
        }
        
    }
}


