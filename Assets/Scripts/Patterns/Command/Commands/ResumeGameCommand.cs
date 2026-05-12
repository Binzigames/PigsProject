using Scripts.Patterns;
using DevConfigs.GameStateMachine;
using UnityEngine;

public class ResumeGameCommand : ICommand
{
    private const int RUN_GAME_TIME = 1;
    private readonly GameManager _gameManager; 

    public ResumeGameCommand (GameManager gameManager)
    {
        _gameManager = gameManager;
    }
    
    public void Execute()
    {
        var runningState = _gameManager.GameStateFactory.GetGameState(GameStateType.RunningState);
        _gameManager.GameStateMachine.TransitionTo(runningState);

        Time.timeScale = RUN_GAME_TIME;
    }

}
