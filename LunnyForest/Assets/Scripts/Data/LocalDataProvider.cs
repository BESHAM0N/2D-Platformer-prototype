using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;

public class LocalDataProvider : MonoBehaviour
{
    public GameProgress gameProgresses;
    
    private const string _gameProgressFileName = "GameProgress";
    private const string _shopFileName = "Shop";
    private const string _playerInventoryFileName = "PlayerInventory";
    private const string _saveFileExtension = ".json";
    private int _numberScene;
    
    private string _savePath => Application.dataPath;

    private void Awake()
    {
        _numberScene = SceneManager.GetActiveScene().buildIndex;
        LoadGameProgress();
    }

    private string GetFullPath(string fileName)
    {
        string fullPath = Path.Combine(_savePath, $"{fileName}{_saveFileExtension}");
        return fullPath;
    }

    private bool IsDataFileExist(string fullPath)
    {
        var result = File.Exists(fullPath);
        if (!result)
        {
            Debug.Log($"Файл по пути {fullPath} не найден, создан пустой файл");
            GenerateFirstFile();
        }
        return result;
    }

    public void GenerateFirstFile()
    {
        gameProgresses = new GameProgress();
        List<Level> levels = new List<Level>
        {
            new Level
            {
                LevelNumber = 1,
                CollectedStarsId = new List<int>(),
                IsCompleted = false
            },
            new Level
            {
                LevelNumber = 2,
                CollectedStarsId = new List<int>(),
                IsCompleted = false
            }
        };
        gameProgresses.CompletedLevels = new List<Level>(levels);
        gameProgresses.Money = 0;
        SavePlayerProgress();
    }

    public void SavePlayerProgress()
    {
        var serializeObject = JsonConvert.SerializeObject(gameProgresses, Formatting.Indented);
        File.WriteAllText(GetFullPath(_gameProgressFileName), serializeObject);
    }

    private bool LoadGameProgress()
    {
        var path = GetFullPath(_gameProgressFileName);
        if (!IsDataFileExist(path))
            return false;

        var jsonText = File.ReadAllText(path);
        if (string.IsNullOrEmpty(jsonText))
        {
            Debug.Log("Файл пустой");
            return false;
        }

        try
        {
            gameProgresses = JsonConvert.DeserializeObject<GameProgress>(jsonText);
        }
        catch (Exception ex)
        {
            Debug.Log($"Произошло исключение при чтении json файла: {ex.Message}");
        }
        return true;
    }
}
