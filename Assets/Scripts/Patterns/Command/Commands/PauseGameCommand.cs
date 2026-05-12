using Scripts.Patterns;
using DevConfigs.GameStateMachine;
using UnityEngine;

public class PauseGameCommand : ICommand
{
    private const int STOP_GAME_TIME = 0;
    private readonly GameManager _gameManager;

    public PauseGameCommand (GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    public void Execute()
    {
        var pauseState = _gameManager.GameStateFactory.GetGameState(GameStateType.PauseState);
        _gameManager.GameStateMachine.TransitionTo(pauseState);

        Time.timeScale = STOP_GAME_TIME; 
    }
}
