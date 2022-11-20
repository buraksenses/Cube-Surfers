using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using CubeSurfers.Managers;
using UnityEngine;

public class GameSaveManager : MonoBehaviour
{
    [SerializeField] private DataManager gameData;

    public bool IsSaveFile()
    {
        return Directory.Exists(Application.persistentDataPath + "mobgta_save");
    }

    public void SaveGame()
    {
        if (!IsSaveFile())
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/mobgta_save");
        }
        if (!Directory.Exists(Application.persistentDataPath + "/mobgta_save/mobgta_data"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/mobgta_save/mobgta_data");
        }

        Debug.Log("Game Saved");
        var json = JsonUtility.ToJson(gameData);
        File.WriteAllText(Application.persistentDataPath + "/mobgta_save/mobgta_data/mobgta_save.txt", json);
    }

    public void LoadGame()
    {
        if (!Directory.Exists(Application.persistentDataPath + "/mobgta_save/mobgta_data"))
        {
            SaveGame();
        }

        if (File.Exists(Application.persistentDataPath + "/mobgta_save/mobgta_data/mobgta_save.txt"))
        {
            var file = File.ReadAllText(Application.persistentDataPath + "/mobgta_save/mobgta_data/mobgta_save.txt");
            JsonUtility.FromJsonOverwrite((string)file, gameData);
        }

        Debug.Log("Game Loaded");
    }
}
