using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(UIDocumentDataContainer), menuName = "ScriptableObject/DataContainer/" + nameof(UIDocumentDataContainer))]
public class UIDocumentDataContainer : BaseStaticDataContainer
{
    [SerializeField] private List<UIDocumentData> _uIDocumentDataList;

    public UIDocumentData GetDocumentByKey(string key)
    {
        foreach (var documentData in _uIDocumentDataList)
        {
            if (documentData.Key == key)
            {
                return documentData;
            }
            else
            {
                Debug.LogWarning($"(The list does't contain this key :{key})");
            }
        }
        return null;
    }
}