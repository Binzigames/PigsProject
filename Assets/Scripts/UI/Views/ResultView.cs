using Scripts.UI.Events;
using UnityEngine.UIElements;

public class ResultView : UIView
{
    private const string SCORE = "score-label";
    private const string CURRENCY = "currency-label";
    private const string BEST_SCORE_TEXT = "best-score-label";
    private const string MENU_BUTTON = "result__menu-button";

    private Label _scoreLabel;
    private Label _currencyLabel;
    private Button _menuButton;
    private VisualElement _bestScoreLabel;

    public ResultView(VisualElement root) : base(root)
    {
        ResultScreenEvents.OnScoreResult += SetScoreResult;
        ResultScreenEvents.OnCurrencyResult += SetCurrencyResult;
        ResultScreenEvents.OnBestScoreResult += BestScoreTextHandler;
    }

    protected override void SetVisualElements()
    {
        _scoreLabel = _root.Q<Label>(SCORE);
        _currencyLabel = _root.Q<Label>(CURRENCY);

        _menuButton = _root.Q<Button>(MENU_BUTTON);

        _bestScoreLabel = _root.Q<VisualElement>(BEST_SCORE_TEXT);
    }
    protected override void RegisterButtonCallbacks()
    {
        _menuButton.RegisterCallback<ClickEvent>(MenuButtonPress);
    }

    private void MenuButtonPress(ClickEvent evt)
    {
        ResultScreenEvents.OnContinueButtonPressed?.Invoke();
    }

    private void SetScoreResult(int score)
    {
        _scoreLabel.text = score.ToString();
    }

    private void SetCurrencyResult(int money)
    {
        _currencyLabel.text = money.ToString();
    }

    private void BestScoreTextHandler(int bestScore)
    {
        bool isShown = bestScore > int.Parse(_scoreLabel.text);
        _bestScoreLabel.SetEnabled(isShown);
    }

}
