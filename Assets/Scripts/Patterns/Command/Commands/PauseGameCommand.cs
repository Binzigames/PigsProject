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
        var pauseState = _gameManager.GameStateFactory.GetGameState(GameStateType.PauseState);
        _gameManager.GameStateMachine.TransitionTo(pauseState);
    }
}
