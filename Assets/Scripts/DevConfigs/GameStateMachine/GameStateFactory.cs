
namespace DevConfigs.GameStateMachine
{
    public class GameStateFactory
    {
        private readonly MenuState _menuState;
        private readonly RunningState _runningState;
        private readonly PauseState _pauseState;
        private readonly ResultGameState _resultState;
        private readonly LoadingState _loadingState;

        public GameStateFactory(
            GameManager gameManager, IScoreManager scoreManager,
                ICurrencyManager currencyManager, GameSpeedTimer gameSpeedTimer,
                    IMusicService musicService, IStaticDataProvider dataProvider,
                        ILoadSceneService loadSceneService, IInputActionProvider inputActionProvider)
        {
            _menuState = new MenuState(scoreManager, currencyManager, musicService, dataProvider);
            _runningState = 
                new RunningState(gameManager, scoreManager, gameSpeedTimer, musicService, dataProvider, inputActionProvider);

            _pauseState = new PauseState(musicService);
            _resultState = new ResultGameState(scoreManager, currencyManager, gameManager, musicService);
            _loadingState = new LoadingState(gameManager, loadSceneService, inputActionProvider);
        }

        public GameState ResolveGameState<T>() where T : GameState
        {
            return typeof(T) switch
            {
                var t when t == typeof(MenuState) => _menuState,
                var t when t == typeof(RunningState) => _runningState,
                var t when t == typeof(PauseState) => _pauseState,
                var t when t == typeof(ResultGameState) => _resultState,
                var t when t == typeof(LoadingState) => _loadingState,
                _ => throw new System.NotImplementedException()
            };
        }
    }
}