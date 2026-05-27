using UnityEngine;

namespace DevConfigs.GameStateMachine
{
    public class ResultGameState : IGameState
    {
        private const int RUN_GAME_TIME = 1;
        private const int STOP_GAME_TIME = 0;

        private SaveData _saveData;
        private IScoreService _scoreService;
        private CurrencyManager _currencyManager;

        public ResultGameState(IScoreService scoreService, CurrencyManager currencyManager, GameManager gameManager)
        {
            _saveData = gameManager.SaveData;
            _scoreService = scoreService;
            _currencyManager = currencyManager;
        }

        public void Enter()
        {
            Time.timeScale = STOP_GAME_TIME;

            _saveData.Money += _currencyManager.TotalCurrency;
            _saveData.BestScore = Mathf.Max(_scoreService.CurrentScore, _saveData.BestScore);
        }

        public void Execute()
        {

        }

        public void Exit()
        {
            Time.timeScale = RUN_GAME_TIME;
        }
    }
}