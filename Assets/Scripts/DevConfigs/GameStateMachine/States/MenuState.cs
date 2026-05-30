namespace DevConfigs.GameStateMachine
{
    public class MenuState : IGameState
    {
        
        private IScoreManager _scoreManager;
        private ICurrencyManager _currencyManager;

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

        public void Execute()
        {

        }

        public void Exit()
        {

        }

    }
}