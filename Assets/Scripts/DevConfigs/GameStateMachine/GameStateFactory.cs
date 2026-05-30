
namespace DevConfigs.GameStateMachine
{
    public class GameStateFactory
    {
        private readonly MenuState _menuState;
        private readonly RunningState _runningState;
        private readonly PauseState _pauseState;
        private readonly ResultGameState _resultState;

        public GameStateFactory(GameManager gameManager, IScoreManager scoreManager, ICurrencyManager currencyManager)
        {
            _menuState = new MenuState(scoreManager, currencyManager);
            _runningState = new RunningState(gameManager, scoreManager);
            _pauseState = new PauseState();
            _resultState = new ResultGameState(scoreManager, currencyManager, gameManager);
        }

        public IGameState ResolveGameState<T>() where T : IGameState
        {
            return typeof(T) switch
            {
                var t when t == typeof(MenuState) => _menuState,
                var t when t == typeof(RunningState) => _runningState,
                var t when t == typeof(PauseState) => _pauseState,
                var t when t == typeof(ResultGameState) => _resultState,
                _ => throw new System.NotImplementedException()
            };
        }
    }
}