using System.Collections.Generic;
using DevConfigs.GameStateMachine;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class MainMenuManager : MonoBehaviour
{
    private const string SETTINGS_SCREEN = "SettingsScreen";
    // private const string HUD_SCREEN = "HUDScreen";

    private List<UIView> _viewList;

    private UIView _mainMenuView;
    private UIView _settingsView;
    // private UIView _hUDView;

    private UIDocument _uiDocument;

    private void OnEnable()
    {
        _uiDocument = GetComponent<UIDocument>();

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

    private void SetupView()
    {
        VisualElement root = _uiDocument.rootVisualElement;

        _mainMenuView = new MainMenuView(root);
        _settingsView = new SettingsView(root.Q<VisualElement>(SETTINGS_SCREEN));
        // _hUDView = new HUDView(root.Q<VisualElement>(HUD_SCREEN));

        AddViewsToList();
    }

    private void AddViewsToList()
    {
        _viewList.Add(_mainMenuView);
        _viewList.Add(_settingsView);
    }

    private void SubscribeToEvents()
    {
        MainMenuEvents.OnSettingButtonPressed += ShowSettingsScreen;
        // MainMenuEvents.OnPlayButtonPressed += ShowHUDScreen;

        SettingsEvents.OnExitSettingsButton += HideSettingsScreen;
    }
    private void UnsubscribeFromEvents()
    {
        MainMenuEvents.OnSettingButtonPressed -= ShowSettingsScreen;
        // MainMenuEvents.OnPlayButtonPressed -= ShowHUDScreen;

        SettingsEvents.OnExitSettingsButton -= HideSettingsScreen;
    }

    private void ShowSettingsScreen()
    {
        _settingsView.Show();
    }

    private void HideSettingsScreen()
    {
        _settingsView.Hide();
    }

    // private void ShowHUDScreen()
    // {
    //     _hUDView.Show();
    // }
}