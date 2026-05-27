
namespace DevConfigs.GameStateMachine
{
    public class GameStateFactory
    {
        private readonly MenuState _menuState;
        private readonly RunningState _runningState;
        private readonly PauseState _pauseState;
        private readonly ResultGameState _resultState;

        public GameStateFactory(GameManager gameManager, IScoreService scoreService, CurrencyManager currencyManager)
        {
            _menuState = new MenuState(scoreService, currencyManager);
            _runningState = new RunningState(scoreService);
            _pauseState = new PauseState();
            _resultState = new ResultGameState(scoreService, currencyManager, gameManager);
        }

        public IGameState GetGameState(GameStateType gameStateType)
        {
            return gameStateType switch
            {
                GameStateType.MenuState => _menuState,
                GameStateType.PauseState => _pauseState,
                GameStateType.RunningState => _runningState,
                GameStateType.EndRunningState => _resultState,
                _ => throw new System.NotImplementedException()
            };
        }
    }
}