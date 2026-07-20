using UnityEngine;
using Zenject;

public class SettingsController : MonoBehaviour
{
    private AudioClip _toggleAudioClip;
    private AudioClip _buttonAudioClip;

    private ISoundService _soundService;
    private AudioDataContainer _audioDataContainer;

    [Inject]
    public void Construct(ISoundService soundService, IStaticDataProvider dataProvider)
    {
        _soundService = soundService;
        _audioDataContainer = dataProvider.GetDataContainer<AudioDataContainer>();
    }

    private void OnEnable()
    {
        SettingsEvents.OnSoundToggle += OnSoundTogglePressed;
        SettingsEvents.OnMusicToggle += OnMusicTogglePressed;
        SettingsEvents.OnHapticToggle += OnHapticTogglePressed;
        SettingsEvents.OnExitSettingsButton += OnExitButtonPressed;

        _toggleAudioClip = _toggleAudioClip != null ? _toggleAudioClip : _audioDataContainer.Toggle;
        _buttonAudioClip = _buttonAudioClip != null ? _buttonAudioClip : _audioDataContainer.Button;
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
        _soundService.PlayClip(_toggleAudioClip);
    }

    private void OnMusicTogglePressed(bool active)
    {
        _soundService.PlayClip(_toggleAudioClip);
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
