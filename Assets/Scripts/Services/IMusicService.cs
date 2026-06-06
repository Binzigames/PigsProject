using UnityEngine;

public interface IMusicService
{
    public void Play();
    public void Pause();
    public void Stop();
    public void PlayMusic(AudioClip music);
}
