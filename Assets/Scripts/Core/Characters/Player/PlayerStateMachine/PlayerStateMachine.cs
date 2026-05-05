
namespace Scripts.Core.Characters
{
    public class PlayerStateMachine
    {
        public IPlayerState CurrentState { get; private set; }

        public IdleState IdleState;
        public RunState RunState;
        public LoseState LoseState;
        
        public PlayerStateMachine(Player player, PlayerAnimation playerAnimation)
        {
            IdleState = new IdleState(playerAnimation);
            RunState = new RunState(player, playerAnimation);
            LoseState = new LoseState(playerAnimation);
        }

        public void Initialize(IPlayerState playerState)
        {
            CurrentState = playerState;
            playerState.Enter();
        }

        public void TransitionTo(IPlayerState playerState)
        {
            CurrentState.Exit();
            CurrentState = playerState;
            playerState.Enter();
        }

        public void Execute()
        {
            CurrentState?.Execute();
        }
    }
}