using UnityEngine;

public interface ISaveProcessor<T> where T : SaveData
{
    public T Load();
    public void Save(T data);
}
