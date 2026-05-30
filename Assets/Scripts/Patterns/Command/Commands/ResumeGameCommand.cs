using DevConfigs.GameStateMachine;
using Scripts.Patterns;

public class ResumeGameCommand : ICommand
{
    private readonly GameManager _gameManager;

    public ResumeGameCommand(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    public void Execute()
    {
        var runningState = _gameManager.GameStateFactory.ResolveGameState<RunningState>();
        _gameManager.GameStateMachine.TransitionTo(runningState);
    }

}
