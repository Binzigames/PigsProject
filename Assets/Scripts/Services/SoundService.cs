using UnityEngine;

public class SoundService : MonoBehaviour, ISoundService
{
    [SerializeField] private AudioSource[] _soundSources;
    
    private bool _isSoundOn = true;

    private void Awake()
    {
        _soundSources ??= GetComponentsInChildren<AudioSource>();
    }

    public void PlayClip(AudioClip clip)
    {
        if (!_isSoundOn)
            return;
        
        var source = GetAvailableAudioSource();
        source.PlayOneShot(clip);
    }

    private AudioSource GetAvailableAudioSource()
    {
        for (int i = 0; i < _soundSources.Length; i++)
        {
            if (!_soundSources[i].isPlaying)
            {
                return _soundSources[i];
            }
        }

        return _soundSources[0]; // default first source
    }

    public void PlayClipAtPoint(AudioClip clip, Vector3 position)
    {
        AudioSource.PlayClipAtPoint(clip, position);
    }

    public void StopAll()
    {
        for (int i = 0; i < _soundSources.Length; i++)
        {
            if (_soundSources[i].isPlaying)
            {
                _soundSources[i].Stop();
            }
        }
    }
}
