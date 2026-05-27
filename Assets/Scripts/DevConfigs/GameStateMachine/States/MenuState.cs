namespace DevConfigs.GameStateMachine
{
    public class MenuState : IGameState
    {
        
        private IScoreService _scoreService;
        private CurrencyManager _currencyManager;

        public MenuState(IScoreService scoreService, CurrencyManager currencyManager)
        {
            _scoreService = scoreService;
            _currencyManager = currencyManager;
        }

        public void Enter()
        {
            _scoreService.ResetScore();
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