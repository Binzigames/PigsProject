using Scripts.Patterns.Commands;
using UnityEngine;
using Zenject;

public class MainMenuController : MonoBehaviour
{
    [Inject] private Player _player;
    [Inject] private GameManager _gameManager;
    
    private void OnEnable()
    {
        MainMenuEvents.OnPlayButtonPressed += StartGame;
    }
    private void OnDisable()
    {
        MainMenuEvents.OnPlayButtonPressed -= StartGame;
    }

    private void StartGame()
    {
        // var startGameCommand = new StartGameCommand(_player, _gameManager);
        // startGameCommand.Execute();

        var runningState = _gameManager.GameStateFactory.GetGameState(GameStateType.RunningState);
        _gameManager.GameStateMachine.TransitionTo(runningState);
    }
}