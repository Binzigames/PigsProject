using UnityEngine;

namespace DevConfigs.GameStateMachine
{
    public class PauseState : IGameState
    {
        private const int RUN_GAME_TIME = 1;
        private const int STOP_GAME_TIME = 0;
        
        public void Enter()
        {
            Time.timeScale = STOP_GAME_TIME;
        }

        public void Exit()
        {
            Time.timeScale = RUN_GAME_TIME;
        }
    }
}