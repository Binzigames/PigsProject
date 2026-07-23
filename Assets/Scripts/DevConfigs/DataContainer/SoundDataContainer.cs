using UnityEngine;

[CreateAssetMenu(fileName = nameof(SoundDataContainer), menuName = "ScriptableObject/DataContainer/" + nameof(SoundDataContainer))]
public class SoundDataContainer : BaseStaticDataContainer
{
    [Header("UI")]
    [SerializeField]
    private AudioClip _button;

    [SerializeField]
    private AudioClip _toggle;

    public AudioClip Button => _button;
    public AudioClip Toggle => _toggle;
}
