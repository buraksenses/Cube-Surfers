using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using CubeSurfers.Managers;
using UnityEngine;

public class GameSaveManager : MonoBehaviour
{
    [SerializeField] private DataManager gameData;

    private void Start()
    {
        LoadGame();
    }

    public bool IsSaveFile()
    {
        return Directory.Exists(Application.persistentDataPath + "cubesurfers_save");
    }

    public void SaveGame()
    {
        if (!IsSaveFile())
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/cubesurfers_save");
        }
        if (!Directory.Exists(Application.persistentDataPath + "/cubesurfers_save/cubesurfers_data"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/cubesurfers_save/cubesurfers_data");
        }

        Debug.Log("Game Saved");
        var json = JsonUtility.ToJson(gameData);
        File.WriteAllText(Application.persistentDataPath + "/cubesurfers_save/cubesurfers_data/cubesurfers_save.txt", json);
    }

    public void LoadGame()
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

        Debug.Log("Game Loaded");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
            SaveGame();
    }
}
