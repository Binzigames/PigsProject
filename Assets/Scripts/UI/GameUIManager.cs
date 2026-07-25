using DevConfigs.GameStateMachine;
using UnityEngine;
using Zenject;

public class GameUIManager : MonoBehaviour
{
    [Inject] private readonly GameManager _gameManager;

    [SerializeField] private MainMenuManager _mainMenuManager;
    [SerializeField] private HUDManager _hUDManager;

    private void Awake()
    {
        _gameManager.GameStateMachine.OnChangeState += HandleUserInterface;
    }

    private void Start()
    {
        if (_gameManager.GameStateMachine.CurrentState != null)
        {
            HandleUserInterface(_gameManager.GameStateMachine.CurrentState);
        }
    }

    private void OnDestroy()
    {
        _gameManager.GameStateMachine.OnChangeState -= HandleUserInterface;
    }

    private void HandleUserInterface(GameState gameState)
    {
        switch (gameState)
        {
            case LoadingState:
                _mainMenuManager.MainMenuView.Hide();
                _hUDManager.HUDView.Hide();
                break;

            case MenuState:
                _mainMenuManager.MainMenuView.Show();
                _hUDManager.HUDView.Hide();
                break;

            case RunningState:
                _mainMenuManager.MainMenuView.Hide();
                _hUDManager.HUDView.Show();
                break;

            default:
                break;
        }
    }

}
