using System.Collections.Generic;
using UnityEngine;

public class StaticDataProvider : IStaticDataProvider
{
    [SerializeField] private List<BaseStaticDataContainer> _dataContainerList;

    public StaticDataProvider(List<BaseStaticDataContainer> dataContainerList)
    {
        _dataContainerList = dataContainerList;
    }
    public T GetDataContainer<T>() where T : BaseStaticDataContainer
    {
        foreach (var container in _dataContainerList)
        {
            if (container is T matchedContainer)
            {
                return matchedContainer;
            }
        }

        Debug.Log($"{typeof(T)} container not found.");
        return null;
    }
}
