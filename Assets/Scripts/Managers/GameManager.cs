using DevConfigs.GameStateMachine;
using Scripts.UI.Events;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameStateMachine _gameStateMachine;
    private GameStateFactory _gameStateFactory;
    public GameStateMachine GameStateMachine => _gameStateMachine;
    public GameStateFactory GameStateFactory => _gameStateFactory;

    private void Awake()
    {
        Init();
        SubToGameplayEvents();
    }

    private void OnDestroy()
    {
        UnsubFromGameplayEvents();
    }

    private void Init()
    {
        _gameStateMachine = new GameStateMachine();
        _gameStateFactory = new GameStateFactory();

        var menuState = _gameStateFactory.GetGameState(GameStateType.MenuState);
        _gameStateMachine.Initialize(menuState);
    }

    private void SubToGameplayEvents()
    {
        GameplayEvents.OnEndRunning += TransitionToResultState;
    }

    private void UnsubFromGameplayEvents()
    {
        GameplayEvents.OnEndRunning -= TransitionToResultState;
    }

    private void TransitionToResultState()
    {
        var endState = _gameStateFactory.GetGameState(GameStateType.EndRunningState);
        _gameStateMachine.TransitionTo(endState);
    }
}
