using UnityEngine.UIElements;

public class MainMenuView : UIView
{
    private const string PLAY_BUTTON = "PlayButton";
    private const string SETTINGS_BUTTON = "SettingsButton";

    private Button _playButton;
    private Button _settingsButton;

    public MainMenuView(VisualElement visualElement) : base(visualElement) { }

    protected override void SetVisualElements()
    {
        _playButton = _root.Q(PLAY_BUTTON) as Button;
        _settingsButton = _root.Q(SETTINGS_BUTTON) as Button;
    }
    protected override void RegisterButtonCallbacks()
    {
        _playButton.RegisterCallback<ClickEvent>(ClickPlayButton);
        _settingsButton.RegisterCallback<ClickEvent>(ClickSettingButton);
    }

    private void ClickPlayButton(ClickEvent evt)
    {
        MainMenuEvents.OnPlayButtonPressed?.Invoke();
    }
    private void ClickSettingButton(ClickEvent evt)
    {
        MainMenuEvents.OnSettingButtonPressed?.Invoke();
    }

}