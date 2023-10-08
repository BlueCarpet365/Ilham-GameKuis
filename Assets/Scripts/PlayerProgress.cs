using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[CreateAssetMenu(
    fileName = "Player Progress",
    menuName = "Trivia Game/Player Progress")]

public class PlayerProgress : ScriptableObject
{
    [System.Serializable]
    public struct MainData
    {
        public int koin;
        public Dictionary<string, int> progressLevel;
    }

    [SerializeField] private string _filename = "contoh.txt";

    [SerializeField] private string _startingLevelPackName = string.Empty;

    public MainData progressData = new MainData();

    public void SimpanProgress()
    {
        //progressData.koin = 200;
        //if (progressData.progressLevel == null)
        //{
        //    progressData.progressLevel = new();
        //}
        //progressData.progressLevel.Add("Level Pack 1", 3);
        //progressData.progressLevel.Add("Level Pack 3", 5);

        if(progressData.progressLevel == null)
        {
            progressData.progressLevel = new();
            progressData.koin = 0;
            progressData.progressLevel.Add(_startingLevelPackName, 1);
        }
#if UNITY_EDITOR
        string directory = Application.dataPath + "/Temporary/";
#elif (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
        string directory = Application.persistentDataPath + "/ProgresLokal/";
#endif
        var path = directory + "/" + _filename;

        //var directory = Application.dataPath + "/Temporary/";
        //var path = directory + _filename;

        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
            Debug.Log("Directory has been Created : " + directory);
        }

        if (File.Exists(path))
        {
            File.Create(path).Dispose();
            Debug.Log("File Created : " + path);
        }

        var fileStream = File.Open(path, FileMode.Open);
        var formatter = new BinaryFormatter();


        fileStream.Flush();
        formatter.Serialize(fileStream, progressData);

        //var writer = new BinaryWriter(fileStream);

        //writer.Write(progressData.koin);

        //foreach (var i in progressData.progressLevel)
        //{
        //writer.Write(i.Key);
        //writer.Write(i.Value);
        //}

        //writer.Dispose();
        fileStream.Dispose();

        Debug.Log($"{_filename} Berhasil disimpan");
    }

    public bool MuatProgress()
    {
#if UNITY_EDITOR
        string directory = Application.dataPath + "/Temporary/";
#elif (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
        string directory = Application.persistentDataPath + "/ProgresLokal/";
#endif
        //var path = directory + "/" + _filename;
        //var directory = Application.dataPath + "/Temporary/";
        var path = directory + _filename;

        var fileStream = File.Open(path, FileMode.OpenOrCreate);
        try
        {
            var formatter = new BinaryFormatter();

            progressData = (MainData)formatter.Deserialize(fileStream);

            fileStream.Dispose();

            Debug.Log($"{progressData.koin}; {progressData.progressLevel.Count}");
            return true;
        }
        catch (System.Exception e)
        {
            Debug.Log($"ERROR : Terjadi keasalahan saat memuat progress\n {e.Message}");
            fileStream.Dispose();


            return false;
        }
    }
}