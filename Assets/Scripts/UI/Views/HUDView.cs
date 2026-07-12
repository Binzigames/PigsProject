using DG.Tweening;
using UnityEngine.UIElements;

public class HUDView : UIView
{
    private const string CARROT_IMAGE = "carrot-image";
    private const string PAUSE_BUTTON = "pause-button";
    private const string SCORE_LABLE = "score-label";
    private const string CURRENCY_LABLE = "currency-label";

    private const float TARGET_SCALE = 1.1f;
    private const float DEFAULT_SCALE = 1f;
    private const float ANIM_DURATION = 0.05f;

    private Button _pauseButton;
    private Label _scoreLable;
    private Label _currencyLable;
    private Image _carrotImage;

    private Tween _scaleAnim;

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
        _carrotImage = _root.Q<Image>(CARROT_IMAGE);
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
        ScaleImageSequence(_carrotImage);
    }

    private Sequence ScaleImageSequence(Image image)
    {
        Sequence sequence = DOTween.Sequence();
        return sequence.Append(ScaleCarrotAnim(TARGET_SCALE, ANIM_DURATION))
                            .Append(ScaleCarrotAnim(DEFAULT_SCALE, ANIM_DURATION));
    }

    private Tween ScaleCarrotAnim(float scale, float duration)
    {
        return _carrotImage.DOScale(scale, duration);
    }
}