
namespace DevConfigs.GameStateMachine
{
    public class RunningState : IGameState
    {
        private IScoreService _scoreService;

        public RunningState(IScoreService scoreService)
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