using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class UIManager : MonoBehaviour
{
    private const string SETTINGS_SCREEN = "SettingsScreen";

    private UIView _mainMenuView;
    private UIView _settingsView;

    private UIDocument _mainMenuDocument;

    private void Awake()
    {
        _mainMenuDocument = GetComponent<UIDocument>();

        SetupView();
        SubscribeToEvents();
    }

    private void OnDestroy()
    {
        UnsubscribeFromEvents();
    }

    private void SetupView()
    {
        VisualElement root = _mainMenuDocument.rootVisualElement;

        _mainMenuView = new MainMenuView(root);
        _settingsView = new SettingsView(root.Q<VisualElement>(SETTINGS_SCREEN));
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

    private void ShowSettingsScreen()
    {
        _settingsView.Show();
    }

    private void HideSettingsScreen()
    {
        _settingsView.Hide();
    }

}