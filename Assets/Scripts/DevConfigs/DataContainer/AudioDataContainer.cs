using UnityEngine;

[CreateAssetMenu(fileName = nameof(AudioDataContainer), menuName = "ScriptableObject/DataContainer/" + nameof(AudioDataContainer))]
public class AudioDataContainer : BaseStaticDataContainer
{
    [Header("UI")]
    [SerializeField]
    private AudioClip _button;

    [SerializeField]
    private AudioClip _toggle;

    public AudioClip Button => _button;
    public AudioClip Toggle => _toggle;
}
