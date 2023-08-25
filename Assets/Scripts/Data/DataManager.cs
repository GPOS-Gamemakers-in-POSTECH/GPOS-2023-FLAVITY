using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class DataManager : MonoBehaviour
{
    static GameObject container;
    static DataManager instance;    
    public static DataManager Instance
    {
        get
        {
            if (!instance)
            {
                container = new GameObject();
                container.name = "DataManager";
                instance = container.AddComponent(typeof(DataManager)) as DataManager;
                DontDestroyOnLoad(container);
            }
            return instance;
        }
    }
    string GameDataFileName = "GameData.json";
    public Data data = new Data();
    public AudioMixer audioMixer;
    public List<Vector3> SavePoint = new List<Vector3>();
    public List<int> SaveRotate = new List<int>();

    public void Awake()
    {
        SavePoint.Add(new Vector3(0,7,-40));
        SaveRotate.Add(0);
        SavePoint.Add(new Vector3(0,7,-40));
        SaveRotate.Add(1);
        SavePoint.Add(new Vector3(0,7,-40));
        SaveRotate.Add(2);
        SavePoint.Add(new Vector3(0,7,-40));
        SaveRotate.Add(3);
    }

    public void ApplyGameData()
    {
        MouseControl.rotCamXAxisSpeed = data.mouse / 100 * 2;
        MouseControl.rotCamYAxisSpeed = data.mouse / 100 * 2;
        if (data.sound == 0) audioMixer.SetFloat("Master", -80);
        else audioMixer.SetFloat("Master", data.sound / 100 * 40 - 40);
    }

    public void LoadGameData()
    {
        string filePath = Application.persistentDataPath + "/" + GameDataFileName;
        if (File.Exists(filePath))
        {
            string FromJsonData = File.ReadAllText(filePath);
            data = JsonUtility.FromJson<Data>(FromJsonData);
        }
    }

    public void SaveGameData()
    {
        string ToJsonData = JsonUtility.ToJson(data, true);
        string filePath = Application.persistentDataPath + "/" + GameDataFileName;

        File.WriteAllText(filePath, ToJsonData);
    }

    private void OnApplicationQuit()
    {
        SaveGameData();
    }
}