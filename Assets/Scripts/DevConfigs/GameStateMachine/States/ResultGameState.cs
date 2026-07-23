using UnityEngine;

namespace DevConfigs.GameStateMachine
{
    public class ResultGameState : GameState
    {
        private readonly SaveData _saveData;
        private readonly IScoreManager _scoreManager;
        private readonly ICurrencyManager _currencyManager;
        private readonly IMusicService _musicService;

        public ResultGameState(
                IScoreManager scoreManager, ICurrencyManager currencyManager,
                GameManager gameManager, IMusicService musicService)
        {
            _saveData = gameManager.SaveData;
            _scoreManager = scoreManager;
            _currencyManager = currencyManager;
            _musicService = musicService;
        }

        public override void Enter()
        {
            _saveData.Money += _currencyManager.TotalCurrency;
            _saveData.BestScore = Mathf.Max(_scoreManager.CurrentScore, _saveData.BestScore);
            _musicService.Pause();
        }
        
    }
}