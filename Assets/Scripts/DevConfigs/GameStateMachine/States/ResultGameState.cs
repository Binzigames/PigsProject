using UnityEngine;

namespace DevConfigs.GameStateMachine
{
    public class ResultGameState : IGameState
    {
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
            _saveData.Money += _currencyManager.TotalCurrency;
            _saveData.BestScore = Mathf.Max(_scoreManager.CurrentScore, _saveData.BestScore);
        }
        
        public void Exit()
        {
        }
    }
}