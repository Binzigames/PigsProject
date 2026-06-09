using System.Diagnostics;
using DevConfigs.GameStateMachine;
using Scripts.Patterns;
using UnityEngine.SceneManagement;
using Zenject;

public class MenuGameCommand : ICommand
{
    private readonly ILoadSceneService _sceneLoadService;
    private readonly GameManager _gameManager;

    public MenuGameCommand(GameManager gameManager, ILoadSceneService sceneLoadService)
    {
        _gameManager = gameManager;
        _sceneLoadService = sceneLoadService;
    }

    public void Execute()
    {
        var menuState = _gameManager.GameStateFactory.ResolveGameState<MenuState>();
        _gameManager.GameStateMachine.TransitionTo(menuState);
        
        //var currentScene = SceneManager.GetActiveScene();
        // SceneManager.LoadScene(currentScene.buildIndex); // TODO: rebuild this logic
        _sceneLoadService.LoadSceneAsyncWithLoading("Game");
    }
}
