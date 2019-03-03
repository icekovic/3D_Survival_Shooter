using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LocalizationManager : MonoBehaviour
{
    private Dictionary<string, string> localizedText;

    private void Awake()
    {
        localizedText = new Dictionary<string, string>();
    }

    void Start()
    {
        
    }

    public void LoadLocalizedText(string fileName)
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, fileName);

        if(CheckIfFilepathExists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            LocalizationData loadedData = JsonUtility.FromJson<LocalizationData> (dataAsJson);

            for (int i = 0; i < loadedData.items.Length; i++)
            {
                localizedText.Add(loadedData.items[i].key, loadedData.items[i].value);
            }


            Debug.Log("Data loaded, dictionary contains: " + localizedText.Count + " entries");
        }

        else
        {
            Debug.LogError("Cannot find file!");
        }
    }

    private bool CheckIfFilepathExists(string filePath)
    {
        if(File.Exists(filePath))
        {
            return true;
        }

        return false;
    }
}
