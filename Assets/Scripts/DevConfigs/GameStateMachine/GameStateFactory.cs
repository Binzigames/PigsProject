
namespace DevConfigs.GameStateMachine
{
    public class GameStateFactory
    {
        private readonly MenuState _menuState;
        private readonly RunningState _runningState;
        private readonly PauseState _pauseState;
        private readonly ResultGameState _resultState;

        public GameStateFactory()
        {
            _menuState = new MenuState();
            _runningState = new RunningState();
            _pauseState = new PauseState();
            _resultState = new ResultGameState();
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