namespace DevConfigs.GameStateMachine
{
    public class MenuState : IGameState
    {
        private IScoreService _scoreService;

        public MenuState(IScoreService scoreService)
        {
            _scoreService = scoreService;
        }

        public void Enter()
        {
            _scoreService.ResetScore();
        }

        public void Execute()
        {

        }

        public void Exit()
        {

        }

    }
}