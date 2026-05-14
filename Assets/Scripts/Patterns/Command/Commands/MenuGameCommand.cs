using Scripts.Patterns;
using UnityEngine.SceneManagement;

public class MenuGameCommand : ICommand
{
    private readonly GameManager _gameManager;

    public MenuGameCommand(GameManager gameManager)
    {
        _gameManager = gameManager;   
    }

    public void Execute()
    {
        var menuState = _gameManager.GameStateFactory.GetGameState(GameStateType.MenuState);
        _gameManager.GameStateMachine.TransitionTo(menuState);
        
        var currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex); // TODO: rebuild this logic
    }
}
