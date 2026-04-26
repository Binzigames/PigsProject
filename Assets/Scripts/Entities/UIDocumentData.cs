using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = nameof(UIDocumentData), menuName = "ScriptableObject/Data/" + nameof(UIDocumentData))]
public class UIDocumentData : ScriptableObject
{
    [SerializeField] private string _key;
    [SerializeField] private VisualTreeAsset _sourceAsset;
    public VisualTreeAsset VisualTreeAsset => _sourceAsset;
    public string Key => _key;
}
