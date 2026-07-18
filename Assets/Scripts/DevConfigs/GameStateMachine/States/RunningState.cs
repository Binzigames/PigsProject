using Scripts.UI.Events;
using UnityEngine;

namespace DevConfigs.GameStateMachine
{
    public class RunningState : GameState
    {
        private readonly GameSpeedTimer _gameSpeedTimer;
        private readonly GameManager _gameManager;
        private readonly IScoreManager _scoreService;

        public RunningState(GameManager gameManager, IScoreManager scoreService, GameSpeedTimer gameSpeedTimer)
        {
            _gameManager = gameManager;
            _scoreService = scoreService;
            _gameSpeedTimer = gameSpeedTimer;
        }
        public override void Enter()
        {
            _scoreService.StartRun();

            GameplayEvents.OnEndRunning += TransitionToResultState;
        }

        public override void Exit()
        {
            _scoreService.StopRun();

            GameplayEvents.OnEndRunning -= TransitionToResultState;
        }

        public override void Execute()
        {
            _gameSpeedTimer.Tick(Time.deltaTime);
        }

        private void TransitionToResultState()
        {
            var resultState = _gameManager.GameStateFactory.ResolveGameState<ResultGameState>();
            _gameManager.GameStateMachine.TransitionTo(resultState);
        }
    }
}