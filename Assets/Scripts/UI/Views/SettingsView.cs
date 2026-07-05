using UnityEngine;
using UnityEngine.UIElements;

public class SettingsView : UIView
{
    private const string EXIT_BUTTON = "ExitSettingsButton";
    private const string SOUND_TOGGLE = "SoundToggle";
    private const string MUSIC_TOGGLE = "MusicToggle";
    private const string HAPTIC_TOGGLE = "HapticToggle";
    private const string SOUND_IMG_CHECKER = "sound-checker";
    private const string MUSIC_IMG_CHECKER = "music-checker";
    private const string HAPTIC_IMG_CHECKER = "haptic-checker";
    private const string GAME_VERSION = "GameVersion";

    private VisualElement _exitSettingsButton;
    private Label _gameVersion;

    private Toggle _soundToggle;
    private Toggle _musicToggle;
    private Toggle _hapticToggle;

    private Image _soundChecker;
    private Image _musicChecker;
    private Image _hapticChecker;

    public SettingsView(VisualElement root) : base(root)
    {
        _gameVersion.text = Application.version;

        _hapticChecker.visible = _hapticToggle.value;
        _musicChecker.visible = _musicToggle.value;
        _soundChecker.visible = _soundToggle.value;
    }

    protected override void SetVisualElements()
    {
        _exitSettingsButton = _root.Q<VisualElement>(EXIT_BUTTON) as Button;

        _soundToggle = _root.Q<Toggle>(SOUND_TOGGLE);
        _musicToggle = _root.Q<Toggle>(MUSIC_TOGGLE);
        _hapticToggle = _root.Q<Toggle>(HAPTIC_TOGGLE);

        _soundChecker = _root.Q<Image>(SOUND_IMG_CHECKER);
        _musicChecker = _root.Q<Image>(MUSIC_IMG_CHECKER);
        _hapticChecker = _root.Q<Image>(HAPTIC_IMG_CHECKER);

        _gameVersion = _root.Q<Label>(GAME_VERSION);
    }

    protected override void RegisterButtonCallbacks()
    {
        _exitSettingsButton.RegisterCallback<ClickEvent>(OnExitSettings);

        _soundToggle.RegisterCallback<ClickEvent>(OnSoundToggle);
        _musicToggle.RegisterCallback<ClickEvent>(OnMusicToggle);
        _hapticToggle.RegisterCallback<ClickEvent>(OnHapticToggle);
    }

    private void OnHapticToggle(ClickEvent evt)
    {
        SettingsEvents.OnHapticToggle?.Invoke(_hapticToggle.value);
        _hapticChecker.visible = _hapticToggle.value;
    }

    private void OnMusicToggle(ClickEvent evt)
    {
        SettingsEvents.OnMusicToggle?.Invoke(_musicToggle.value);
        _musicChecker.visible = _musicToggle.value;
    }

    private void OnSoundToggle(ClickEvent evt)
    {
        SettingsEvents.OnSoundToggle?.Invoke(_soundToggle.value);
        _soundChecker.visible = _soundToggle.value;
    }

    private void OnExitSettings(ClickEvent click)
    {
        SettingsEvents.OnExitSettingsButton?.Invoke();
    }
}