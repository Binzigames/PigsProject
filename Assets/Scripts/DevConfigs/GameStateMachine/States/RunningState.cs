
namespace DevConfigs.GameStateMachine
{
    public class RunningState : IGameState
    {
        private IScoreManager _scoreService;

        public RunningState(IScoreManager scoreService)
        {
            _scoreService = scoreService;
        }
        public void Enter()
        {
            _scoreService.StartRun();
        }

        public void Execute()
        {
        
        }

        public void Exit()
        {
            _scoreService.StopRun();
        }
    }
}