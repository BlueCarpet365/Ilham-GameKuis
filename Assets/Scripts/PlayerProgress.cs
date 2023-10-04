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
    public MainData progressData = new MainData();

    public void SimpanProgress()
    {
        progressData.koin = 200;
        if (progressData.progressLevel == null)
            progressData.progressLevel = new();
        progressData.progressLevel.Add("Level Pack 1", 3);
        progressData.progressLevel.Add("Level Pack 3", 5);

        var directory = Application.dataPath + "/Temporary";
        var path =  directory + "/" + _filename;

        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
            Debug.Log("Directory has been created : " + directory);
        }

        if (File.Exists(path))
        {
            File.Create(path).Dispose();
            Debug.Log("File Created: " + path);
        }

        var fileStream = File.Open(path, FileMode.Open);
        var formatter = new BinaryFormatter();

        fileStream.Flush();
        formatter.Serialize(fileStream, progressData);

        //var writer = new BinaryWriter(fileStream);

        //writer.Write(progressData.koin);
        //foreach(var i in progressData.progressLevel)
        //{
        //    writer.Write(i.Key);
        //    writer.Write(i.Value);
        //}

        //writer.Dispose();
        fileStream.Dispose();

        Debug.Log($"{_filename} Berhasil disimpan");
    }

    public bool MuatProgress()
    {
        var directory = Application.dataPath + "/Temporary";
        var path = directory + "/" + _filename;
        
        try
        {
            var fileStream = File.Open(path, FileMode.Open);
            var formatter = new BinaryFormatter();

            progressData = (MainData)formatter.Deserialize(fileStream);

            fileStream.Dispose();

            Debug.Log($"{progressData.koin}; {progressData.progressLevel.Count}");
        }
        catch (System.Exception e)
        {
            Debug.Log($"ERROR: Terjadi kesalahan saat memuat progress\n{e.Message}");

            return false;
        }

        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
