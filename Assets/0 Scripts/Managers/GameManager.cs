using UnityEngine;

namespace CubeSurfers.Managers
{
    public class GameManager
    {
        public static bool isGameOver = false;
        public static bool isGameStarted = false;
        [SerializeField] private DataManager gameData;

        public static void ResetValues()
        {
            isGameOver = false;
            isGameStarted = false;
        }

    }
}


