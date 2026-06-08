using UnityEngine.UIElements;

public class HUDView : UIView
{
    private const string PAUSE_BUTTON = "pause-button";
    private const string SCORE_LABLE = "score-label";
    private const string CURRENCY_LABLE = "currency-label";

    private Button _pauseButton;
    private Label _scoreLable;
    private Label _currencyLable;

    public HUDView(VisualElement root) : base(root)
    {
        HUDEvents.OnChangedScore += UpdateScore;
        HUDEvents.OnChangedCurrency += UpdateCurrency;
    }

    protected override void SetVisualElements()
    {
        _pauseButton = _root.Q<Button>(PAUSE_BUTTON);
        _scoreLable = _root.Q<Label>(SCORE_LABLE);
        _currencyLable = _root.Q<Label>(CURRENCY_LABLE);
    }

    protected override void RegisterButtonCallbacks()
    {
        _pauseButton.clicked += ClickPauseButton;
    }

    private void ClickPauseButton()
    {
        HUDEvents.OnPausePressed?.Invoke();
    }

    private void UpdateScore(int value)
    {
        _scoreLable.text = value.ToString();
    }

    private void UpdateCurrency(int value)
    {
        _currencyLable.text = value.ToString();
    }

}