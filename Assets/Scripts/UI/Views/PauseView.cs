using UnityEngine.UIElements;

public class PauseView : UIView
{
    private const string RESUME_BUTTON = "resume-button";
    private const string ENDRUN_BUTTON = "endrun-button";

    private Button _resumeButton;
    private Button _endRunButton;

    public PauseView(VisualElement root) : base(root) { }

    protected override void SetVisualElements()
    {
        _resumeButton = _root.Q<Button>(RESUME_BUTTON);
        _endRunButton = _root.Q<Button>(ENDRUN_BUTTON);
    }

    protected override void RegisterButtonCallbacks()
    {
        _resumeButton.RegisterCallback<ClickEvent>(ResumeButtonPress);
        _endRunButton.RegisterCallback<ClickEvent>(EndRunButtonPress);
    }

    private void ResumeButtonPress(ClickEvent evt)
    {
        PauseEvents.OnResumeButtonPressed?.Invoke();
    }

    private void EndRunButtonPress(ClickEvent evt)
    {
        PauseEvents.OnEndRunButtonPressed?.Invoke();
    }

}