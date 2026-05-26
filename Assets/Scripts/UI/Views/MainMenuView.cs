using UnityEngine.UIElements;

public class MainMenuView : UIView
{
    private const string PLAY_BUTTON = "PlayButton";
    private const string SETTINGS_BUTTON = "SettingsButton";
    private const string BEST_SCORE_LABEL = "best_score-label";
    private const string TOTAL_MONEY_LABEL = "money-label";

    private Button _playButton;
    private Button _settingsButton;
    private Label _bestScoreLabel;
    private Label _totalMoneyLabel;

    public MainMenuView(VisualElement visualElement) : base(visualElement)
    {
        MainMenuEvents.OnShowedBestScore += UpdateBestScoreLabel;
        MainMenuEvents.OnShowedTotalMoney += UpdateTotalMoneyLabel;
    }

    protected override void SetVisualElements()
    {
        _playButton = _root.Q(PLAY_BUTTON) as Button;
        _settingsButton = _root.Q(SETTINGS_BUTTON) as Button;
        _bestScoreLabel = _root.Q(BEST_SCORE_LABEL) as Label;
        _totalMoneyLabel = _root.Q(TOTAL_MONEY_LABEL) as Label;
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

    private void UpdateBestScoreLabel(int bestScore)
    {
        _bestScoreLabel.text = bestScore.ToString();
    }

    private void UpdateTotalMoneyLabel(int total)
    {
        _totalMoneyLabel.text = total.ToString();
    }

}