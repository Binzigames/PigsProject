
using Scripts.UI.Events;

namespace DevConfigs.GameStateMachine
{
    public class RunningState : IGameState
    {
        private readonly GameManager _gameManager;
        private readonly IScoreManager _scoreService;

        public RunningState(GameManager gameManager, IScoreManager scoreService)
        {
            _gameManager = gameManager;
            _scoreService = scoreService;
        }
        public void Enter()
        {
            _scoreService.StartRun();

            GameplayEvents.OnEndRunning += TransitionToResultState;
        }
        public void Exit()
        {
            _scoreService.StopRun();

            GameplayEvents.OnEndRunning -= TransitionToResultState;
        }

        private void TransitionToResultState()
        {
            var resultState = _gameManager.GameStateFactory.ResolveGameState<ResultGameState>();
            _gameManager.GameStateMachine.TransitionTo(resultState);
        }
    }
}