using System.Collections.Generic;
using Scripts.UI.Events;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class HUDManager : MonoBehaviour
{
    private const string HUD_ELEMENTS = "HUDElements";
    private const string PAUSE_SCREEN = "PauseScreen";
    private const string RESULT_SCREEN = "ResultScreen";

    private UIDocument _document;

    private UIView _hudView;
    private UIView _pauseView;
    private UIView _resultView;

    private VisualElement _hudViewElements;

    private readonly List<UIView> _viewList = new();

    private void OnEnable()
    {
        _document = GetComponent<UIDocument>();

        SetupView();
        SubscribeToEvents();
    }

    private void OnDisable()
    {
        UnsubscribeFromEvents();

        foreach (var view in _viewList)
        {
            view.Dispose();
        }
    }

    private void SubscribeToEvents()
    {
        HUDEvents.OnPausePressed += ShowPausePanel;
        PauseEvents.OnResumeButtonPressed += ShowHUDElements;

        GameplayEvents.OnEndRunning += ShowResultScreen;
    }

    private void UnsubscribeFromEvents()
    {
        HUDEvents.OnPausePressed -= ShowPausePanel;
        PauseEvents.OnResumeButtonPressed -= ShowHUDElements;

        GameplayEvents.OnEndRunning -= ShowResultScreen;
    }

    private void SetupView()
    {
        var root = _document.rootVisualElement;

        _hudView = new HUDView(root);
        _pauseView = new PauseView(root.Q<VisualElement>(PAUSE_SCREEN));
        _resultView = new ResultView(root.Q<VisualElement>(RESULT_SCREEN));


        _hudViewElements = root.Q<VisualElement>(HUD_ELEMENTS);

        AddViewToList();
    }

    private void AddViewToList()
    {
        _viewList.Add(_hudView);
    }

    private void ShowPausePanel()
    {
        _pauseView.Show();
        _hudViewElements.style.display = DisplayStyle.None;
    }

    private void ShowHUDElements()
    {
        _pauseView.Hide();
        _hudViewElements.style.display = DisplayStyle.Flex;
    }

    private void ShowResultScreen()
    {
        _resultView.Show();
        _hudViewElements.style.display = DisplayStyle.None;
    }

}
