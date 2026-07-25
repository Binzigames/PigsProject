using DevConfigs.GameStateMachine;

public class LoadingState : GameState
{
    private readonly GameManager _gameManager;
    private readonly ILoadSceneService _loadSceneService;

    public LoadingState(GameManager gameManager, ILoadSceneService loadSceneService)
    {
        _gameManager = gameManager;
        _loadSceneService = loadSceneService;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Execute()
    {
        if (!_loadSceneService.IsLoading)
        {
            TransitionToMainMenu();
        }
    }

    private void TransitionToMainMenu()
    {
        var menuState = _gameManager.GameStateFactory.ResolveGameState<MenuState>();
        _gameManager.GameStateMachine.TransitionTo(menuState);
    }
}