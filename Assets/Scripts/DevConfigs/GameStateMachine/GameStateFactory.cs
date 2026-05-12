
namespace DevConfigs.GameStateMachine
{
    public class GameStateFactory
    {
        private readonly MenuState _menuState;
        private readonly RunningState _runningState;
        private readonly PauseState _pauseState;
        private readonly EndRunningState _endRunningState;

        public GameStateFactory()
        {
            _menuState = new MenuState();
            _runningState = new RunningState();
            _pauseState = new PauseState();
            _endRunningState = new EndRunningState();
        }

        public IGameState GetGameState(GameStateType gameStateType)
        {
            return gameStateType switch
            {
                GameStateType.MenuState => _menuState,
                GameStateType.PauseState => _pauseState,
                GameStateType.RunningState => _runningState,
                GameStateType.EndRunningState => _endRunningState,
                _ => throw new System.NotImplementedException()
            };
        }
    }
}