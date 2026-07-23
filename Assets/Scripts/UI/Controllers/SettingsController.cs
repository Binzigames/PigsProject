using UnityEngine;
using Zenject;

public class SettingsController : MonoBehaviour
{
    private AudioClip _toggleAudioClip;
    private AudioClip _buttonAudioClip;

    private IMusicService _musicService;
    private ISoundService _soundService;
    private SoundDataContainer _soundDataContainer;

    [Inject]
    public void Construct(ISoundService soundService, IMusicService musicService, IStaticDataProvider dataProvider)
    {
        _soundService = soundService;
        _musicService = musicService;
        
        _soundDataContainer = dataProvider.GetDataContainer<SoundDataContainer>();
    }

    private void OnEnable()
    {
        SettingsEvents.OnSoundToggle += OnSoundTogglePressed;
        SettingsEvents.OnMusicToggle += OnMusicTogglePressed;
        SettingsEvents.OnHapticToggle += OnHapticTogglePressed;
        SettingsEvents.OnExitSettingsButton += OnExitButtonPressed;

        _toggleAudioClip = _toggleAudioClip != null ? _toggleAudioClip : _soundDataContainer.Toggle;
        _buttonAudioClip = _buttonAudioClip != null ? _buttonAudioClip : _soundDataContainer.Button;
    }

    private void OnDisable()
    {
        SettingsEvents.OnSoundToggle -= OnSoundTogglePressed;
        SettingsEvents.OnMusicToggle -= OnMusicTogglePressed;
        SettingsEvents.OnHapticToggle -= OnHapticTogglePressed;
        SettingsEvents.OnExitSettingsButton -= OnExitButtonPressed;
    }

    private void OnSoundTogglePressed(bool active)
    {
        _soundService.ToggleSound(active);

        _soundService.PlayClip(_toggleAudioClip); //play button sfx
    }

    private void OnMusicTogglePressed(bool active)
    {
        _musicService.ToggleMusic(active);

        _soundService.PlayClip(_toggleAudioClip); //play button sfx
    }

    private void OnHapticTogglePressed(bool active)
    {
        _soundService.PlayClip(_toggleAudioClip);
    }

    private void OnExitButtonPressed()
    {
        _soundService.PlayClip(_buttonAudioClip);
    }
}
