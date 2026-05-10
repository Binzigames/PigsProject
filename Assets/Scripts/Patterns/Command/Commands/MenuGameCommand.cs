using Scripts.Patterns;
using DevConfigs.GameStateMachine;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuGameCommand : ICommand
{
    private const int RUN_GAME_TIME = 1;
    private readonly GameManager _gameManager;

    public MenuGameCommand(GameManager gameManager)
    {
        _gameManager = gameManager;   
    }

    public void Execute()
    {
        var menuState = _gameManager.GameStateMachine.factoryGameState.GetGameState(GameStateType.MenuState);
        _gameManager.GameStateMachine.TransitionTo(menuState);

        Time.timeScale = RUN_GAME_TIME;
        
        var currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex); // TODO: rebuild this logic
    }
}
