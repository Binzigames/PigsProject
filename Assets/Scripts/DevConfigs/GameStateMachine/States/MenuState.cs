namespace DevConfigs.GameStateMachine
{
    public class MenuState : GameState
    {
        
        private readonly IScoreManager _scoreManager;
        private readonly ICurrencyManager _currencyManager;

        public MenuState(IScoreManager scoreManager, ICurrencyManager currencyManager)
        {
            _scoreManager = scoreManager;
            _currencyManager = currencyManager;
        }

        public override void Enter()
        {
            _scoreManager.ResetScore();
            _currencyManager.ResetCurrency();
        }
        

    }
}