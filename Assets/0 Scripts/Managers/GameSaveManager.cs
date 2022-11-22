using System.IO;
using UnityEngine;

namespace CubeSurfers.Managers
{
    public class GameSaveManager : MonoBehaviour
    {
        public DataManager gameData;

        private void Start()
        {
            LoadGame();
            
            //===== EVENT ASSIGNMENTS =====
            EventManager.onCollectDiamond += SaveGame;
            EventManager.onCollectDiamond += gameData.IncreaseGemCount;
        }
    
        private bool IsSaveFile()
        {
            return Directory.Exists(Application.persistentDataPath + "cubesurfers_save");
        }
    
        private void SaveGame()
        {
            if (!IsSaveFile())
            {
                Directory.CreateDirectory(Application.persistentDataPath + "/cubesurfers_save");
            }
            if (!Directory.Exists(Application.persistentDataPath + "/cubesurfers_save/cubesurfers_data"))
            {
                Directory.CreateDirectory(Application.persistentDataPath + "/cubesurfers_save/cubesurfers_data");
            }
            var json = JsonUtility.ToJson(gameData);
            File.WriteAllText(Application.persistentDataPath + "/cubesurfers_save/cubesurfers_data/cubesurfers_save.txt", json);
        }
    
        private void LoadGame()
        {
            if (!Directory.Exists(Application.persistentDataPath + "/cubesurfers_save/cubesurfers_data"))
            {
                SaveGame();
            }
    
            if (File.Exists(Application.persistentDataPath + "/cubesurfers_save/cubesurfers_data/cubesurfers_save.txt"))
            {
                var file = File.ReadAllText(Application.persistentDataPath + "/cubesurfers_save/cubesurfers_data/cubesurfers_save.txt");
                JsonUtility.FromJsonOverwrite((string)file, gameData);
            }
        }
    
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.U))
                SaveGame();
        }
    }
}

