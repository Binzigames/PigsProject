using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private const string DATA_PATH = "/playerData";
    private void Awake()
    {
        Save(DATA_PATH, "anona");
        Debug.Log(File.Open(Application.persistentDataPath + DATA_PATH, FileMode.Open));
    }
    public void Save(string RelativePath, string data)
    {
        var path = Application.persistentDataPath + RelativePath;

        if (File.Exists(path))
        {
            File.Delete(path); // Delete old data
        }

        FileStream stream = File.Create(path);
        stream.Close();

        File.WriteAllText(path, JsonUtility.ToJson(data));
    }

    public void Load()
    {

    }
}
