namespace DevConfigs.GameStateMachine
{
    public class MenuState : IGameState
    {
        
        private readonly IScoreManager _scoreManager;
        private readonly ICurrencyManager _currencyManager;

        public MenuState(IScoreManager scoreManager, ICurrencyManager currencyManager)
        {
            _scoreManager = scoreManager;
            _currencyManager = currencyManager;
        }

        public void Enter()
        {
            _scoreManager.ResetScore();
            _currencyManager.ResetCurrency();
        }
        
        public void Exit()
        {

        }

    }
}