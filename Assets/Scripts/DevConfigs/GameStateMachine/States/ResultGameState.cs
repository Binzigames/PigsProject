using UnityEngine;

namespace DevConfigs.GameStateMachine
{
    public class ResultGameState : IGameState
    {
        private const int RUN_GAME_TIME = 1;
        private const int STOP_GAME_TIME = 0;

        private SaveData _saveData;
        private IScoreManager _scoreManager;
        private ICurrencyManager _currencyManager;

        public ResultGameState(IScoreManager scoreManager, ICurrencyManager currencyManager, GameManager gameManager)
        {
            _saveData = gameManager.SaveData;
            _scoreManager = scoreManager;
            _currencyManager = currencyManager;
        }

        public void Enter()
        {
            Time.timeScale = STOP_GAME_TIME;

            _saveData.Money += _currencyManager.TotalCurrency;
            _saveData.BestScore = Mathf.Max(_scoreManager.CurrentScore, _saveData.BestScore);
        }
        
        public void Exit()
        {
            Time.timeScale = RUN_GAME_TIME;
        }
    }
}