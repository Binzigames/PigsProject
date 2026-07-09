using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class MainMenuManager : MonoBehaviour
{
    private const string SETTINGS_SCREEN = "SettingsScreen";
    private UIDocument _document;

    private UIView _mainMenuView;
    private UIView _settingsView;

    private readonly List<UIView> _viewList = new();
    private CancellationTokenSource _cts;

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
        MainMenuEvents.OnSettingButtonPressed += ShowSettingsScreen;

        SettingsEvents.OnExitSettingsButton += HideSettingsScreen;
    }
    private void UnsubscribeFromEvents()
    {
        MainMenuEvents.OnSettingButtonPressed -= ShowSettingsScreen;

        SettingsEvents.OnExitSettingsButton -= HideSettingsScreen;
    }

    private void SetupView()
    {
        VisualElement root = _document.rootVisualElement;

        _mainMenuView = new MainMenuView(root);
        _settingsView = new SettingsView(root.Q<VisualElement>(SETTINGS_SCREEN));

        AddViewToList();
    }

    private void AddViewToList()
    {
        _viewList.Add(_mainMenuView);
        _viewList.Add(_settingsView);
    }

    private void ShowSettingsScreen()
    {
        _settingsView.Show();
    }

    private async void HideSettingsScreen()
    {
        _cts?.Dispose();
        _cts = new CancellationTokenSource();

        try
        {
            await UniTask.Delay(1000, cancellationToken: _cts.Token);
            _settingsView.Hide();
        }
        catch(OperationCanceledException)
        {
            return;
        }
        finally
        {
            _settingsView.Hide();
        }
    }
}