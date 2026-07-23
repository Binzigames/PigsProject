using UnityEngine;

namespace DevConfigs.GameStateMachine
{
    public class PauseState : GameState
    {
        private const int RUN_GAME_TIME = 1;
        private const int STOP_GAME_TIME = 0;

        private readonly IMusicService _musicService;

        public PauseState(IMusicService musicService)
        {
            _musicService = musicService;
        }

        public override void Enter()
        {
            Time.timeScale = STOP_GAME_TIME;

            _musicService.Pause();
        }

        public override void Exit()
        {
            Time.timeScale = RUN_GAME_TIME;
        }
    }
}