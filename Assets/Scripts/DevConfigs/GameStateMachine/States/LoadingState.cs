using DevConfigs.GameStateMachine;
using UnityEngine.InputSystem;

public class LoadingState : GameState
{
    private const string GAMEPLAY_ACTION_MAP_ID = "Gameplay";

    private readonly GameManager _gameManager;
    private readonly InputActionMap _inputActionMap;
    private readonly ILoadSceneService _loadSceneService;

    public LoadingState(GameManager gameManager, ILoadSceneService loadSceneService, IInputActionProvider inputProvider)
    {
        _gameManager = gameManager;
        _loadSceneService = loadSceneService;
        
        _inputActionMap = inputProvider.GetInputActionMap(GAMEPLAY_ACTION_MAP_ID);
    }

    public override void Enter()
    {
        _inputActionMap.Disable();
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