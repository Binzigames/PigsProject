using UnityEngine;

public interface ISoundService
{
    public void PlayClip(AudioClip clip);
    public void PlayClipAtPoint(AudioClip clip, Vector3 position);
    public void StopAll();
}
