using UnityEngine;

namespace DevConfigs.GameStateMachine
{
    public class PauseState : GameState
    {
        private const int RUN_GAME_TIME = 1;
        private const int STOP_GAME_TIME = 0;
        
        public override void Enter()
        {
            Time.timeScale = STOP_GAME_TIME;
        }

        public override void Exit()
        {
            Time.timeScale = RUN_GAME_TIME;
        }
    }
}