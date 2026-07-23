using Scripts.UI.Events;
using UnityEngine;

namespace DevConfigs.GameStateMachine
{
    public class RunningState : GameState
    {
        private readonly GameSpeedTimer _gameSpeedTimer;
        private readonly GameManager _gameManager;
        private readonly IScoreManager _scoreService;
        private readonly IMusicService _musicService;
        private readonly MusicDataContainer _musicDataContainer;

        public RunningState(
            GameManager gameManager, IScoreManager scoreService,
                GameSpeedTimer gameSpeedTimer, IMusicService musicService, IStaticDataProvider dataProvider)
        {
            _gameManager = gameManager;
            _scoreService = scoreService;
            _gameSpeedTimer = gameSpeedTimer;
            _musicService = musicService;
            _musicDataContainer = dataProvider.GetDataContainer<MusicDataContainer>();
        }
        public override void Enter()
        {
            GameplayEvents.OnEndRunning += TransitionToResultState;
            
            _scoreService.StartRun();

            var runningMusic = _musicDataContainer.GetMusicByType(MusicType.Running);
            if (runningMusic != null)
            {
                _musicService.PlayMusic(runningMusic);
            }

        }

        public override void Exit()
        {
            GameplayEvents.OnEndRunning -= TransitionToResultState;

            _scoreService.StopRun();
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