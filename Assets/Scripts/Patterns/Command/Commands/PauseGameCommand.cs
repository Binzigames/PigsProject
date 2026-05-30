using DevConfigs.GameStateMachine;
using Scripts.Patterns;

public class PauseGameCommand : ICommand
{
    private readonly GameManager _gameManager;

    public PauseGameCommand (GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    public void Execute()
    {
        var pauseState = _gameManager.GameStateFactory.ResolveGameState<PauseState>();
        _gameManager.GameStateMachine.TransitionTo(pauseState);
    }
}
