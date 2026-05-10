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

    private void HandleUserInterface(IGameState gameState)
    {
        switch (gameState)
        {
            case MenuState :
            _mainMenuManager.gameObject.SetActive(true);
            _hUDManager.gameObject.SetActive(false);
            break;

            case RunningState :
            _mainMenuManager.gameObject.SetActive(false);
            _hUDManager.gameObject.SetActive(true);
            break;

            default:
            break;
        }
    }

}
