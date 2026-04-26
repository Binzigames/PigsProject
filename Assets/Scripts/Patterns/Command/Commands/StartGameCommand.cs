using DevConfigs.GameStateMachine;

namespace Scripts.Patterns.Commands
{
    public class StartGameCommand : ICommand
    {
        private GameManager _gameManager;
        // private PlayerState => run
        // private AudioSoruce _musicSource
        public StartGameCommand(GameManager gameManager)
        {
            _gameManager = gameManager;
        }
        public void Execute()
        {
            var runState = _gameManager.GameStateMachine.factoryGameState.GetGameState(GameStateType.RunningState);
            _gameManager.GameStateMachine.TransitionTo(runState);
        }
    }
}