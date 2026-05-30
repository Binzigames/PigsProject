
using DevConfigs.GameStateMachine;

namespace Scripts.Patterns.Commands
{
    public class StartGameCommand : ICommand
    {
        private GameManager _gameManager;
        private Player _player;
        // private AudioSoruce _musicSource
        public StartGameCommand(Player player, GameManager gameManager)
        {
            _player = player;
            _gameManager = gameManager;
        }
        public void Execute()
        {
            var runGameState = _gameManager.GameStateFactory.ResolveGameState<RunningState>();
            _gameManager.GameStateMachine.TransitionTo(runGameState);

            var runPlayerState = _player.PlayerStateMachine.RunState;
            _player.PlayerStateMachine.TransitionTo(runPlayerState);
        }
    }
}