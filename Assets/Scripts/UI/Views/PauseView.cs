using UnityEngine.UIElements;

public class PauseView : UIView
{
    private const string PAUSE_SCREEN_BACKGROUND = "background";
    private const string PAUSE_SCREEN_BACKGROUND_ANIM_CLASS = "background-out";
    private const string PAUSE_PANEL_ANIM_CLASS = "pause_panel_in";

    private const string PAUSE_PANEL = "pause__pause-panel";
    private const string RESUME_BUTTON = "resume-button";
    private const string ENDRUN_BUTTON = "endrun-button";

    private VisualElement _background;
    private VisualElement _pausePanel;
    private Button _resumeButton;
    private Button _endRunButton;

    public PauseView(VisualElement root) : base(root)
    {
        PauseEvents.OnShownPausePanel += AnimatePanel;

        _pausePanel.AddToClassList(PAUSE_PANEL_ANIM_CLASS);
        _background.AddToClassList(PAUSE_SCREEN_BACKGROUND_ANIM_CLASS);
    }

    protected override void SetVisualElements()
    {
        _background = _root.Q<VisualElement>(PAUSE_SCREEN_BACKGROUND);
        _pausePanel = _root.Q<VisualElement>(PAUSE_PANEL);
        _resumeButton = _root.Q<Button>(RESUME_BUTTON);
        _endRunButton = _root.Q<Button>(ENDRUN_BUTTON);
    }

    protected override void RegisterButtonCallbacks()
    {
        _resumeButton.RegisterCallback<ClickEvent>(ResumeButtonPress);
        _endRunButton.RegisterCallback<ClickEvent>(EndRunButtonPress);
    }

    private void AnimatePanel()
    {
        _pausePanel.RemoveFromClassList(PAUSE_PANEL_ANIM_CLASS);
        _background.RemoveFromClassList(PAUSE_SCREEN_BACKGROUND_ANIM_CLASS);
    }

    private void ResumeButtonPress(ClickEvent evt)
    {
        _pausePanel.AddToClassList(PAUSE_PANEL_ANIM_CLASS);
        _background.AddToClassList(PAUSE_SCREEN_BACKGROUND_ANIM_CLASS);
        PauseEvents.OnResumeButtonPressed?.Invoke();
    }

    private void EndRunButtonPress(ClickEvent evt)
    {
        PauseEvents.OnEndRunButtonPressed?.Invoke();
    }

}