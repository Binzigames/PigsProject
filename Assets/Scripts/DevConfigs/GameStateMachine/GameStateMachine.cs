namespace DevConfigs.GameStateMachine
{
    public class GameStateMachine
    {
        public IGameState CurrentState {get; private set;}
        public FactoryGameState factoryGameState;

        public GameStateMachine()
        {
            factoryGameState = new FactoryGameState();
        }

        public void Initialize(IGameState gameState)
        {
            CurrentState = gameState;
            gameState.Enter();
        }
        public void TransitionTo(IGameState gameState)
        {
            CurrentState.Exit();
            CurrentState = gameState;
            gameState.Enter();
        }
        public void Execute() // each per frame
        {
            CurrentState?.Execute();
        }
    }   
}