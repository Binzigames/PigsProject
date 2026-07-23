using System;
using UnityEngine;

[Serializable]
public struct Music
{
    [SerializeField]
    private AudioClip _musicClip;

    [SerializeField]
    private MusicType _musicType;

    public readonly AudioClip MusicClip => _musicClip;
    public readonly MusicType MusicType => _musicType;
}
