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

    private void SetScoreResult(string result)
    {
        _scoreLabel.text = result;
        // (if result > bestresult) { _bestscoreText visible}
    }

    private void SetCurrencyResult(string result)
    {
        _currencyLabel.text = result;
    }


}
