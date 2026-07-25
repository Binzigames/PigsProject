using DevConfigs.GameStateMachine;
using Scripts.Patterns;

public class LoadMenuCommand : ICommand
{
    private const string SCENE_NAME_TAG = "Game";
    private readonly ILoadSceneService _sceneLoadService;
    private readonly GameManager _gameManager;

    public LoadMenuCommand(GameManager gameManager, ILoadSceneService sceneLoadService)
    {
        _gameManager = gameManager;
        _sceneLoadService = sceneLoadService;
    }

    public void Execute()
    {
        var loadingState = _gameManager.GameStateFactory.ResolveGameState<LoadingState>();
        _gameManager.GameStateMachine.TransitionTo(loadingState);
        
        _sceneLoadService.LoadSceneAsyncWithLoading(SCENE_NAME_TAG);
    }
}
