using UnityEngine;

public class PlayerPrefsSaveProcessor<T> : ISaveProcessor<T> where T : SaveData, new()
{
    private const string DATA_KEY = "data";
    private T _saveData;
    public T Load()
    {
        if (_saveData != null)
        {
            return _saveData;
        }

        var jsonData = PlayerPrefs.GetString(DATA_KEY);
        _saveData = string.IsNullOrEmpty(jsonData) ? new T() : JsonUtility.FromJson<T>(jsonData);
        return _saveData;
    }

    public void Save(T data)
    {
        var jsonData = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(DATA_KEY, jsonData);
        PlayerPrefs.Save();
    }

}
