using DevConfigs.GameStateMachine;
using Scripts.UI.Events;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameStateMachine _gameStateMachine;
    public GameStateMachine GameStateMachine => _gameStateMachine;

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
        
        var menuState = _gameStateMachine.factoryGameState.GetGameState(GameStateType.MenuState);
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
        var endState = _gameStateMachine.factoryGameState.GetGameState(GameStateType.EndRunningState);
        _gameStateMachine.TransitionTo(endState);

        var endGameCommand = new EndGameCommand();
        endGameCommand.Execute();
    }
}
