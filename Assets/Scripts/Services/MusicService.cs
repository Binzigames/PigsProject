using UnityEngine;

public class MusicService : MonoBehaviour, IMusicService
{
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioClip _currentMusic;

    private bool _isMusicOn = true;

    private void Awake()
    {
        if (_musicSource == null)
        {
            _musicSource = GetComponentInChildren<AudioSource>();
        }
    }

    public void Play()
    {
        if (!_isMusicOn)
            return;

        _musicSource.Play();
    }

    public void Pause()
    {
        _musicSource.Pause();
    }

    public void Stop()
    {
        _musicSource.Stop();
    }

    public void PlayMusic(AudioClip clip)
    {
        _musicSource.clip = clip;
        _musicSource.Play();

        _currentMusic = _musicSource.clip;
    }

}
