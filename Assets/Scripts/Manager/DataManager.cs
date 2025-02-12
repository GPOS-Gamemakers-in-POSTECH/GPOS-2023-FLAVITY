using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DataManager : MonoSingleton<DataManager>
{
    string GameDataFileName = "GameData.json";
    public Data data = new();
    public AudioMixer audioMixer;
    public List<Vector3> SavePoint = new();
    public List<int> SaveRotate = new();

    public void Start()
    {
        SavePoint.Add(new Vector3(0, 7, -40));
        SaveRotate.Add(0);
        SavePoint.Add(new Vector3(0, 7.5f, 78));
        SaveRotate.Add(0);
        SavePoint.Add(new Vector3(-4.75f, 7.5f, 173));
        SaveRotate.Add(1);
        SavePoint.Add(new Vector3(-3, 11.5f, 200));
        SaveRotate.Add(2);
        SavePoint.Add(new Vector3(2.25f, 41.125f, 206.75f));
        SaveRotate.Add(2);
        SavePoint.Add(new Vector3(19.75f, 38.25f, 215.375f));
        SaveRotate.Add(3);
        SavePoint.Add(new Vector3(17.25f, 78.125f, 241.625f));
        SaveRotate.Add(2);
        SavePoint.Add(new Vector3(-57.25f, 79.125f, 278.375f));
        SaveRotate.Add(1);
        SavePoint.Add(new Vector3(-41.75f, 79.125f, 293));
        SaveRotate.Add(1);
        SavePoint.Add(new Vector3(-22.625f, -130.875f, 293));
        SaveRotate.Add(3);
        SavePoint.Add(new Vector3(37.375f, -130.875f, 353));
        SaveRotate.Add(3);
    }

    public void LoadGameData()
    {
        string filePath = Application.dataPath + "/" + GameDataFileName;
        if (File.Exists(filePath))
        {
            string FromJsonData = File.ReadAllText(filePath);
            data = JsonUtility.FromJson<Data>(FromJsonData);
        }
    }

    public void SaveGameData()
    {
        string ToJsonData = JsonUtility.ToJson(data, true);
        string filePath = Application.dataPath + "/" + GameDataFileName;

        File.WriteAllText(filePath, ToJsonData);
    }

    private void OnApplicationQuit()
    {
        SaveGameData();
    }
}