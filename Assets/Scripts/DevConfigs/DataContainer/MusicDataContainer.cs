using UnityEngine;

[CreateAssetMenu(fileName = nameof(MusicDataContainer), menuName = "ScriptableObject/DataContainer/" + nameof(MusicDataContainer))]
public class MusicDataContainer : BaseStaticDataContainer
{
    [SerializeField]
    private Music[] _musics;

    public AudioClip GetMusicByType(MusicType musicType)
    {
        for (int i = 0; i < _musics.Length; i++)
        {
            if (musicType == _musics[i].MusicType)
            {
                return _musics[i].MusicClip;
            }
        }

        Debug.LogWarning($"{this} has no audio datas");
        return null;
    }

}
